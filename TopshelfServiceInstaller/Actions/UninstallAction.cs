using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TopshelfServiceInstaller.Actions
{
    public class UninstallAction
    {
        private readonly InstalacaoConfig _config;
        private readonly MainWizardForm _form;
        private bool _erro;

        public static void DoAction(InstalacaoConfig config, MainWizardForm form)
        {
            new UninstallAction(config, form).DoAction();
        }

        private UninstallAction(InstalacaoConfig config, MainWizardForm form)
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
                "Desinstalando serviço Windows",
                "Removendo arquivos",
                "Finalizando desinstalação"
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
                    // Desinstalando serviço Windows
                    case 0:
                        Do_DesinstalarServico();
                        break;

                    // Removendo arquivos
                    case 1:
                        Do_RemoverArquivosInstalacao();
                        break;

                    // Finalizando desinstalação
                    case 2:
                        Do_Finalizar();
                        break;
                }

                if (!_erro)
                    _form.TS_CompleteStep(step);
            }

            if (!_erro)
                Do_Sucesso();
        }

        private void Do_Sucesso()
        {
            _form.TS_ShowMessage("Desinstalação finalizada com sucesso!", "Desinstalação!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _form.TS_ResetForm();
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

            hKeySoftware.DeleteSubKeyTree(Constants.REGISTRY_ENTRY_OWNER, false);
        }

        private void Do_RemoverArquivosInstalacao()
        {
            _erro = false;

            try
            {
                var listaExcluir = EnumerarArquivosParaExcluir(new DirectoryInfo(_config.DiretorioDestino));

                foreach (var excluir in listaExcluir)
                {
                    if (excluir.IsDirectory)
                    {
                        Directory.Delete(excluir.Path);
                    }
                    else
                    {
                        File.Delete(excluir.Path);
                    }
                }
            }
            catch (Exception ex)
            {
                _form.TS_ShowMessage(
                    string.Format(
                        "Ocorreu o seguinte erro ao remover os arquivos:\n\n{0}",
                        InstalacaoConfig.SERVICE_EXE,
                        ex.Message),
                    "Erro ao desinstalar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                _erro = true;
            }
        }

        private void Do_DesinstalarServico()
        {
            _erro = false;

            var exePath = Path.Combine(_config.DiretorioDestino, InstalacaoConfig.SERVICE_EXE);
            var procInfo = new ProcessStartInfo(exePath);

            procInfo.Arguments = "uninstall";

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
                        "O serviço {0} retornou código {1} ao ser desinstalado:\n\n{2}{3}",
                        InstalacaoConfig.SERVICE_EXE,
                        proc.ExitCode,
                        proc.StandardError.ReadToEnd(),
                        proc.StandardOutput.ReadToEnd()),
                    "Erro ao desinstalar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                _erro = true;
            }
        }

        private IList<UninstallFileInfo> EnumerarArquivosParaExcluir(DirectoryInfo dirRoot)
        {
            var lista = new List<UninstallFileInfo>();

            foreach (FileInfo file in dirRoot.GetFiles())
            {
                lista.Add(new UninstallFileInfo { Path = file.FullName, IsDirectory = false });
            }

            foreach (DirectoryInfo dir in dirRoot.GetDirectories())
            {
                lista.AddRange(EnumerarArquivosParaExcluir(new DirectoryInfo(dir.FullName)));
                lista.Add(new UninstallFileInfo { Path = dir.FullName, IsDirectory = true });
            }

            return lista.ToArray();
        }
    }
}
