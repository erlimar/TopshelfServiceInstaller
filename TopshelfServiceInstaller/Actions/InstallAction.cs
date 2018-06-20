using System;
using System.IO;
using System.Linq;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace TopshelfServiceInstaller.Actions
{
    public class InstallAction
    {
        private const string DATA_FILE_FOLDER = "Data";
        private const string DATA_FILE_NAME = "Target_Setup_Data.zip";

        private readonly InstalacaoConfig _config;
        private readonly MainWizardForm _form;
        private bool _erro;

        public static void DoAction(InstalacaoConfig config, MainWizardForm form)
        {
            var proc = new Thread(new ThreadStart(() =>
            {
                new InstallAction(config, form).DoAction();
            }));

            proc.Start();
        }

        private InstallAction(InstalacaoConfig config, MainWizardForm form)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            if (form == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            _config = config;
            _form = form;
        }

        public void DoAction()
        {
            var steps = new string[]
            {
                "Criando diretórios",
                "Descompactando arquivos",
                "Instalando serviço Windows",
                "Iniciando serviço Windows",
                "Finalizando instalação"
            };

            _form.TS_InitProgress(steps);
            _form.TS_GoToWizard(MainWizardForm.WizardPanel.Progress);

            for (var stepCount = 0; stepCount < steps.Length; stepCount++)
            {
                if (_erro) break;

                var step = steps[stepCount];

                _form.TS_SelectStep(step);

                switch (stepCount)
                {
                    // Criando diretórios
                    case 0:
                        Do_CriarDiretorios();
                        break;

                    // Descompactando arquivos
                    case 1:
                        Do_DescompactarArquivosInstalacao();
                        break;

                    // Instalando serviço Windows
                    case 2:
                        Do_InstalarServicoWindows();
                        break;

                    // Iniciando serviço Windows
                    case 3:
                        Do_IniciarServicoWindows();
                        break;

                    // Finalizando instalação
                    case 4:
                        Do_Finalizar();
                        break;
                }

                if (!_erro)
                    _form.TS_CompleteStep(step);
            }

            if (!_erro)
                Do_Sucesso();
        }

        private void Do_CriarDiretorios()
        {
            _erro = false;

            if (!Directory.Exists(_config.DiretorioDestino))
            {
                Directory.CreateDirectory(_config.DiretorioDestino);
            }
        }

        private Stream GetResource(string resourcePath)
        {
            var programType = typeof(Program);
            var assembly = programType.Assembly;

            var resourceFullPath = Path
                .Combine(programType.Namespace, resourcePath)
                .Replace("/", ".")
                .Replace("\\", ".");

            return assembly.GetManifestResourceStream(resourceFullPath);
        }

        private void Do_DescompactarArquivosInstalacao()
        {
            _erro = false;

            using (var dataFile = GetResource(Path.Combine(DATA_FILE_FOLDER, DATA_FILE_NAME)))
            {
                using (var zip = new ZipArchive(dataFile))
                {
                    // Criando diretorios
                    foreach (var entry in zip.Entries.Where(w => string.IsNullOrEmpty(w.Name)))
                    {
                        var dirPath = Path.GetFullPath(Path.Combine(_config.DiretorioDestino, entry.FullName));

                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }
                    }

                    // Extraindo arquivos
                    foreach (var entry in zip.Entries.Where(w => !string.IsNullOrEmpty(w.Name)))
                    {
                        var filePath = Path.GetFullPath(Path.Combine(_config.DiretorioDestino, entry.FullName));

                        entry.ExtractToFile(filePath, true);
                    }
                }
            }
        }

        private void Do_InstalarServicoWindows()
        {
            _erro = false;

            var exePath = Path.Combine(_config.DiretorioDestino, InstalacaoConfig.SERVICE_EXE);
            var procInfo = new ProcessStartInfo(exePath);

            procInfo.Arguments = "install";

            procInfo.WorkingDirectory = _config.DiretorioDestino;
            procInfo.UseShellExecute = false;
            procInfo.WindowStyle = ProcessWindowStyle.Hidden;
            procInfo.RedirectStandardError = true;
            procInfo.RedirectStandardOutput = true;

            var proc = Process.Start(procInfo);

            proc.WaitForExit();

            if (proc.ExitCode != 0)
            {
                _form.TS_ShowMessage(
                    string.Format(
                        "O serviço {0} retornou código {1} ao ser instalado:\n\n{2}{3}",
                        InstalacaoConfig.SERVICE_EXE,
                        proc.ExitCode,
                        proc.StandardError.ReadToEnd(),
                        proc.StandardOutput.ReadToEnd()),
                    "Erro ao instalar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                _erro = true;
            }
        }

        private void Do_IniciarServicoWindows()
        {
            _erro = false;

            var exePath = Path.Combine(_config.DiretorioDestino, InstalacaoConfig.SERVICE_EXE);
            var procInfo = new ProcessStartInfo(exePath);

            procInfo.Arguments = "start";

            procInfo.WorkingDirectory = _config.DiretorioDestino;

            procInfo.UseShellExecute = false;
            procInfo.WindowStyle = ProcessWindowStyle.Hidden;
            procInfo.RedirectStandardError = true;
            procInfo.RedirectStandardOutput = true;

            var proc = Process.Start(procInfo);

            proc.WaitForExit();

            if (proc.ExitCode != 0)
            {
                _form.TS_ShowMessage(
                    string.Format(
                        "O serviço {0} retornou código {1} ao ser iniciado:\n\n{2}{3}",
                        InstalacaoConfig.SERVICE_EXE,
                        proc.ExitCode,
                        proc.StandardError.ReadToEnd(),
                        proc.StandardOutput.ReadToEnd()),
                    "Erro ao iniciar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                _erro = true;
            }
        }

        private void Do_Finalizar()
        {
            _erro = false;

            RegistryKey hKeySoftware = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);

            if (hKeySoftware == null)
            {
                _form.TS_ShowMessage("Erro ao ler registro HKEY_LOCAL_MACHINE\\SOFTWARE do windows.", "Erro de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _erro = true;

                return;
            }

            var hKeyOwner = hKeySoftware.CreateSubKey(Constants.REGISTRY_ENTRY_OWNER, true);

            if (hKeyOwner == null)
            {
                _form.TS_ShowMessage("Erro ao escrever no registro do windows.", "Erro de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _erro = true;

                return;
            }

            // Gravando valores no registro
            hKeyOwner.SetValue(Constants.REGISTRY_ENTRY_NAME, _config.NomeServico, RegistryValueKind.String);
            hKeyOwner.SetValue(Constants.REGISTRY_ENTRY_DISPLAY, _config.TituloServico, RegistryValueKind.String);
            hKeyOwner.SetValue(Constants.REGISTRY_ENTRY_VERSION, _config.Versao, RegistryValueKind.String);
            hKeyOwner.SetValue(Constants.REGISTRY_ENTRY_INSTALL_DIRECTORY, _config.DiretorioDestino, RegistryValueKind.String);

            // Verificando se valores foram gravados com sucesso
            object hKeyName = hKeyOwner.GetValue(Constants.REGISTRY_ENTRY_NAME);
            object hKeyDisplayName = hKeyOwner.GetValue(Constants.REGISTRY_ENTRY_DISPLAY);
            object hKeyVersion = hKeyOwner.GetValue(Constants.REGISTRY_ENTRY_VERSION);
            object hKeyInstallDirectory = hKeyOwner.GetValue(Constants.REGISTRY_ENTRY_INSTALL_DIRECTORY);

            if (hKeyName == null || hKeyName.GetType() != typeof(string) ||
                hKeyDisplayName == null || hKeyDisplayName.GetType() != typeof(string) ||
                hKeyVersion == null || hKeyVersion.GetType() != typeof(string) ||
                hKeyInstallDirectory == null || hKeyInstallDirectory.GetType() != typeof(string))
            {
                _form.TS_ShowMessage("Erro ao escrever valores no registro do windows.", "Erro de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _erro = true;

                return;
            }
        }

        private void Do_Sucesso()
        {
            _form.TS_ShowMessage("Instalação finalizada com sucesso!", "Instalação!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _form.TS_ResetForm();
        }
    }
}
