using System;
using System.Threading;
using System.Windows.Forms;

namespace TopshelfServiceInstaller.Actions
{
    public class InstallAction
    {
        private readonly InstalacaoConfig _config;
        private readonly MainWizardForm _form;

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
                "Criar diretórios",
                "Descompactar arquivos de instalação",
                "Copiar arquivos do serviço",
                "Instalar serviço Windows",
                "Iniciar serviço Windows"
            };

            _form.TS_InitProgress(steps);
            _form.TS_GoToWizard(MainWizardForm.WizardPanel.Progress);

            for (var stepCount = 0; stepCount < steps.Length; stepCount++)
            {
                var step = steps[stepCount];

                _form.TS_SelectStep(step);

                switch (stepCount)
                {
                    // Criar diretórios
                    case 0:
                        Do_CriarDiretorios();
                        break;

                    // Descompactar arquivos de instalação
                    case 1:
                        Do_DescompactarArquivosInstalacao();
                        break;

                    // Copiar arquivos do serviço
                    case 2:
                        Do_CopiarArquivosServico();
                        break;

                    // Instalar serviço Windows
                    case 3:
                        Do_InstalarServicoWindows();
                        break;

                    // Iniciar serviço Window
                    case 4:
                        Do_IniciarServicoWindows();
                        break;
                }

                _form.TS_CompleteStep(step);
            }

            Do_Sucesso();
        }

        private void Do_CriarDiretorios()
        {
            Thread.Sleep(1000);
        }

        private void Do_DescompactarArquivosInstalacao()
        {
            Thread.Sleep(1000);
        }

        private void Do_CopiarArquivosServico()
        {
            Thread.Sleep(1000);
        }

        private void Do_InstalarServicoWindows()
        {
            Thread.Sleep(1000);
        }

        private void Do_IniciarServicoWindows()
        {
            Thread.Sleep(1000);
        }

        private void Do_Sucesso()
        {
            _form.TS_ShowMessage("Instalação finalizada com sucesso!", "Instalação!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _form.TS_ResetForm();
        }
    }
}
