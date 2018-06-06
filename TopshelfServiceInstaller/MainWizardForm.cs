﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            if (_instalacao == null)
            {
                lblInstAtual_NenhumaInstalacao.Show();
            }

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
            lblInstAtual_NomeServico_Valor.Text = _instalacao?.NomeServico;
            lblInstAtual_StatusServico_Valor.Text = _instalacao?.StatusServico.ToString();
            lblInstAtual_Versao_Valor.Text = _instalacao?.Versao;
        }

        private InstalacaoConfig ObterInstalacaoAtual()
        {
            return null;

            return new InstalacaoConfig
            {
                Diretorio = Environment.CurrentDirectory,
                NomeServico = "Nome serviço",
                StatusServico = StatusServico.Parado,
                Versao = "0.1.2-pre"
            };
        }
    }
}