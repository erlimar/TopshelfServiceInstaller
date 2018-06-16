using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopshelfServiceInstaller
{
    public partial class MainWizardForm : Form
    {
        private const int MAX_WIZARD = 1;
        private int _wizard;
        private InstalacaoConfig _instalacao;

        public MainWizardForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;
            _instalacao = ObterInstalacaoAtual();
        }

        private void MainWizardForm_Load(object sender, EventArgs e)
        {
            UpdateInstalacaoAtual();
            GoToWizard(1);

            ActiveControl = lnkSair;
        }

        private void lnkSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void GoToWizard(int wizard)
        {
            HideWizards();
            int oldWizard = _wizard;

            switch (_wizard = wizard)
            {
                case 1:
                    pnlWizard_1.Show();
                    break;

                default:
                    _wizard = oldWizard;
                    throw new Exception(string.Format("Identificação WIZARD inválida: {0}", wizard));
            }
        }

        private void HideWizards()
        {
            pnlWizard_1.Hide();
        }

        private void UpdateInstalacaoAtual()
        {
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
            lblInstAtual_Diretorio_Valor.Text = _instalacao?.Diretorio;
            lblInstAtual_NomeServico_Valor.Text = _instalacao?.TituloServico;
            lblInstAtual_StatusServico_Valor.Text = _instalacao?.StatusServico.ToString();
            lblInstAtual_Versao_Valor.Text = _instalacao?.Versao;
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
                NomeServico = hKeyName.ToString(),
                TituloServico = hKeyDisplayName.ToString(),
                Diretorio = hKeyInstallDirectory.ToString(),
                StatusServico = ObterStatusServico(hKeyName.ToString()),
                Versao = hKeyVersion.ToString()
            };
        }

        private StatusServico ObterStatusServico(string nomeServico)
        {
            // TODO: Verificar status do serviço por nome
            return StatusServico.Parado;
        }

        private void lblInstAtual_Diretorio_Valor_Click(object sender, EventArgs e)
        {
            string path = lblInstAtual_Diretorio_Valor.Text;

            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }
    }
}
