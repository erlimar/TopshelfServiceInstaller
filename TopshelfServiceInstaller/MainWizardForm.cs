using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;
using TopshelfServiceInstaller.Actions;

namespace TopshelfServiceInstaller
{
    public partial class MainWizardForm : Form
    {
        public enum WizardPanel
        {
            StartButtons = 1,
            PreInstall,
            Progress
        }

        private WizardPanel _wizard;
        private InstalacaoConfig _instalacao;

        public MainWizardForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void MainWizardForm_Load(object sender, EventArgs e)
        {
            ActiveControl = lnkSair;
            ResetForm();
        }

        private delegate void ResetFormDelegate();
        public void TS_ResetForm()
        {
            Invoke(new ResetFormDelegate(ResetForm), new object[] { });
        }

        private void ResetForm()
        {
            UpdateInstalacaoAtual();
            GoToWizard(WizardPanel.StartButtons);
            HabilitarBotoes();
        }

        private void HabilitarBotoes()
        {
            bool instalado = _instalacao != null;

            btnInstalar.Enabled = !instalado;
            btnReinstalar.Enabled = instalado;
            btnAtualizar.Enabled = instalado;
            btnDesinstalar.Enabled = instalado;
        }

        private void lnkSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private delegate void GoToWizardDelegate(WizardPanel wizard);
        public void TS_GoToWizard(WizardPanel wizard)
        {
            Invoke(new GoToWizardDelegate(GoToWizard), new object[]
            {
                wizard
            });
        }

        public void GoToWizard(WizardPanel wizard)
        {
            HideWizards();
            AlignWizards();

            WizardPanel oldWizard = _wizard;

            switch (_wizard = wizard)
            {
                case WizardPanel.StartButtons:
                    pnlWizard_1.Show();
                    break;

                case WizardPanel.PreInstall:
                    pnlPreInstalar.Show();
                    break;

                case WizardPanel.Progress:
                    pnlProgresso.Show();
                    break;

                default:
                    _wizard = oldWizard;
                    throw new Exception(string.Format("Identificação WIZARD inválida: {0}", wizard));
            }
        }

        private delegate void InitProgressDelegate(string[] steps);
        public void TS_InitProgress(string[] steps)
        {
            Invoke(new InitProgressDelegate(InitProgress), new object[] {
                steps
            });
        }

        public void InitProgress(string[] steps)
        {
            lblProgresso_Titulo.Text = "";

            clblProgresso_Tarefas.Items.Clear();

            clblProgresso_Tarefas.Items.AddRange(steps);

            clblProgresso_Tarefas.Enabled = false;
            clblProgresso_Tarefas.SelectedIndex = 0 > steps.Length ? -1 : 0;
        }

        private void UpdateProgress()
        {
            pgbProgresso_Barra.Maximum = clblProgresso_Tarefas.Items.Count;
            pgbProgresso_Barra.Value = clblProgresso_Tarefas.CheckedItems.Count;
        }

        private delegate void SelectStepDelegate(string stepName);
        public void TS_SelectStep(string stepName)
        {
            Invoke(new SelectStepDelegate(SelectStep), new object[]
            {
                stepName
            });
        }

        public void SelectStep(string stepName)
        {
            clblProgresso_Tarefas.SelectedItem = stepName;
            lblProgresso_Titulo.Text = string.Format("Executando tarefa: {0}", stepName);
            UpdateProgress();
        }

        private delegate void CompleteStepDelegate(string stepName);
        public void TS_CompleteStep(string stepName)
        {
            Invoke(new CompleteStepDelegate(CompleteStep), new object[]
            {
                stepName
            });
        }

        public void CompleteStep(string stepName)
        {
            var itemIdx = clblProgresso_Tarefas.Items.IndexOf(stepName);

            clblProgresso_Tarefas.SetItemCheckState(itemIdx, CheckState.Checked);
            UpdateProgress();
        }

        private void AlignWizards()
        {
            pnlProgresso.Location = pnlWizard_1.Location;
            pnlProgresso.Size = pnlWizard_1.Size;

            pnlPreInstalar.Location = pnlWizard_1.Location;
            pnlPreInstalar.Size = pnlWizard_1.Size;
        }

        private void HideWizards()
        {
            pnlWizard_1.Hide();

            pnlProgresso.Hide();
            pnlPreInstalar.Hide();
        }

        private void UpdateInstalacaoAtual()
        {
            _instalacao = ObterInstalacaoAtual();

            PreencherDadosInstalacaoAtual();

            lblInstAtual_NenhumaInstalacao.Visible = _instalacao == null;

            lblInstAtual_Diretorio.Visible
                = lblInstAtual_Diretorio_Valor.Visible
                = lblInstAtual_NomeServico.Visible
                = lblInstAtual_NomeServico_Valor.Visible
                = lblInstAtual_StatusServico.Visible
                = lblInstAtual_StatusServico_Valor.Visible
                = lblInstAtual_Versao.Visible
                = lblInstAtual_Versao_Valor.Visible
                = !lblInstAtual_NenhumaInstalacao.Visible;
        }

        private void PreencherDadosInstalacaoAtual()
        {
            lblInstAtual_Diretorio_Valor.Text = _instalacao?.DiretorioDestino;
            lblInstAtual_NomeServico_Valor.Text = _instalacao?.TituloServico;
            lblInstAtual_StatusServico_Valor.Text = _instalacao?.StatusServico.ToString();
            lblInstAtual_Versao_Valor.Text = _instalacao?.Versao;
        }

        private InstalacaoConfig CriarInstalacao(string diretorioDestino)
        {
            return new InstalacaoConfig
            {
                DiretorioOrigem = Path.GetDirectoryName(GetType().Assembly.Location),
                DiretorioDestino = diretorioDestino,
                NomeServico = InstalacaoConfig.SERVICE_NAME,
                TituloServico = InstalacaoConfig.SERVICE_TITLE,
                Versao = InstalacaoConfig.SERVICE_VERSION,
                StatusServico = StatusServico.Inacessivel
            };
        }

        private InstalacaoConfig ObterInstalacaoAtual()
        {
            RegistryKey hKeySoftware = Registry.LocalMachine.OpenSubKey("SOFTWARE");

            if (hKeySoftware == null) return null;

            var hKeyOwner = hKeySoftware.OpenSubKey(Constants.REGISTRY_ENTRY_OWNER);

            if (hKeyOwner == null) return null;

            object hKeyName = hKeyOwner.GetValue(Constants.REGISTRY_ENTRY_NAME);
            object hKeyDisplayName = hKeyOwner.GetValue(Constants.REGISTRY_ENTRY_DISPLAY);
            object hKeyVersion = hKeyOwner.GetValue(Constants.REGISTRY_ENTRY_VERSION);
            object hKeyInstallDirectory = hKeyOwner.GetValue(Constants.REGISTRY_ENTRY_INSTALL_DIRECTORY);

            if (hKeyName == null || hKeyName.GetType() != typeof(string) ||
                hKeyDisplayName == null || hKeyDisplayName.GetType() != typeof(string) ||
                hKeyVersion == null || hKeyVersion.GetType() != typeof(string) ||
                hKeyInstallDirectory == null || hKeyInstallDirectory.GetType() != typeof(string))
            {
                return null;
            }

            return new InstalacaoConfig
            {
                DiretorioOrigem = Path.GetDirectoryName(GetType().Assembly.Location),
                DiretorioDestino = hKeyInstallDirectory.ToString(),
                NomeServico = hKeyName.ToString(),
                TituloServico = hKeyDisplayName.ToString(),
                StatusServico = ObterStatusServico(hKeyName.ToString()),
                Versao = hKeyVersion.ToString()
            };
        }

        private StatusServico ObterStatusServico(string nomeServico)
        {
            try
            {
                ServiceController sc = new ServiceController(nomeServico);

                return (StatusServico)(int)sc.Status;
            }
            catch (Exception)
            {
                return StatusServico.Inacessivel;
            }
        }

        private void lblInstAtual_Diretorio_Valor_Click(object sender, EventArgs e)
        {
            string path = lblInstAtual_Diretorio_Valor.Text;

            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }

        private void btnDesinstalar_Click(object sender, EventArgs e)
        {
            UninstallAction.DoAction(_instalacao, this);
        }

        private void btnPreInstalar_Cancelar_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnPreInstalar_Instalar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPreInstalar_DiretorioDestino.Text))
            {
                MessageBox.Show(this, "Selecione um diretório para instalação primeiro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var config = CriarInstalacao(txtPreInstalar_DiretorioDestino.Text);

            InstallAction.DoAction(config, this);
        }

        private void btnInstalar_Click(object sender, EventArgs e)
        {
            GoToWizard(WizardPanel.PreInstall);
        }

        private void btnPreInstalar_SelecionarDiretorioDestino_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            dialog.Description = "Selecione o diretório de instalação.";
            dialog.SelectedPath = txtPreInstalar_DiretorioDestino.Text;

            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                txtPreInstalar_DiretorioDestino.Text = dialog.SelectedPath;
            }
        }

        private void pnlPreInstalar_VisibleChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPreInstalar_DiretorioDestino.Text))
            {
                var programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                var installPath = Path.Combine(programFilesPath, Constants.REGISTRY_ENTRY_OWNER, Constants.REGISTRY_ENTRY_NAME);

                txtPreInstalar_DiretorioDestino.Text = installPath;
            }
        }

        private delegate void ShowMessageDelegate(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
        public void TS_ShowMessage(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Invoke(new ShowMessageDelegate(ShowMessage), new object[]
            {
                text,
                caption,
                buttons,
                icon
            });
        }

        private void ShowMessage(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(this, text, caption, buttons, icon);
        }
    }
}
