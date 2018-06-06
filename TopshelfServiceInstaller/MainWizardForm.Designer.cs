namespace TopshelfServiceInstaller
{
    partial class MainWizardForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWizardForm));
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxInstAtual = new System.Windows.Forms.GroupBox();
            this.lblInstAtual_Diretorio_Valor = new System.Windows.Forms.LinkLabel();
            this.lblInstAtual_NenhumaInstalacao = new System.Windows.Forms.Label();
            this.lblInstAtual_Versao_Valor = new System.Windows.Forms.Label();
            this.lblInstAtual_Versao = new System.Windows.Forms.Label();
            this.lblInstAtual_StatusServico_Valor = new System.Windows.Forms.Label();
            this.lblInstAtual_StatusServico = new System.Windows.Forms.Label();
            this.lblInstAtual_NomeServico_Valor = new System.Windows.Forms.Label();
            this.lblInstAtual_NomeServico = new System.Windows.Forms.Label();
            this.lblInstAtual_Diretorio = new System.Windows.Forms.Label();
            this.pnlWizard_1 = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnDesinstalar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lnkSair = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.gbxInstAtual.SuspendLayout();
            this.pnlWizard_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgLogo
            // 
            this.imgLogo.BackColor = System.Drawing.Color.Transparent;
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.Location = new System.Drawing.Point(26, 12);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(256, 256);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTitulo.Location = new System.Drawing.Point(295, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(363, 29);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Instalador do Serviço Topshelf X";
            // 
            // gbxInstAtual
            // 
            this.gbxInstAtual.BackColor = System.Drawing.Color.Transparent;
            this.gbxInstAtual.Controls.Add(this.lblInstAtual_Diretorio_Valor);
            this.gbxInstAtual.Controls.Add(this.lblInstAtual_NenhumaInstalacao);
            this.gbxInstAtual.Controls.Add(this.lblInstAtual_Versao_Valor);
            this.gbxInstAtual.Controls.Add(this.lblInstAtual_Versao);
            this.gbxInstAtual.Controls.Add(this.lblInstAtual_StatusServico_Valor);
            this.gbxInstAtual.Controls.Add(this.lblInstAtual_StatusServico);
            this.gbxInstAtual.Controls.Add(this.lblInstAtual_NomeServico_Valor);
            this.gbxInstAtual.Controls.Add(this.lblInstAtual_NomeServico);
            this.gbxInstAtual.Controls.Add(this.lblInstAtual_Diretorio);
            this.gbxInstAtual.Location = new System.Drawing.Point(300, 85);
            this.gbxInstAtual.Name = "gbxInstAtual";
            this.gbxInstAtual.Size = new System.Drawing.Size(469, 183);
            this.gbxInstAtual.TabIndex = 2;
            this.gbxInstAtual.TabStop = false;
            this.gbxInstAtual.Text = "Instalação atual";
            // 
            // lblInstAtual_Diretorio_Valor
            // 
            this.lblInstAtual_Diretorio_Valor.AutoSize = true;
            this.lblInstAtual_Diretorio_Valor.Location = new System.Drawing.Point(106, 41);
            this.lblInstAtual_Diretorio_Valor.Name = "lblInstAtual_Diretorio_Valor";
            this.lblInstAtual_Diretorio_Valor.Size = new System.Drawing.Size(143, 13);
            this.lblInstAtual_Diretorio_Valor.TabIndex = 9;
            this.lblInstAtual_Diretorio_Valor.TabStop = true;
            this.lblInstAtual_Diretorio_Valor.Text = "C:\\Arquivos de Programas\\X";
            // 
            // lblInstAtual_NenhumaInstalacao
            // 
            this.lblInstAtual_NenhumaInstalacao.AutoSize = true;
            this.lblInstAtual_NenhumaInstalacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstAtual_NenhumaInstalacao.ForeColor = System.Drawing.Color.Gray;
            this.lblInstAtual_NenhumaInstalacao.Location = new System.Drawing.Point(126, 86);
            this.lblInstAtual_NenhumaInstalacao.Name = "lblInstAtual_NenhumaInstalacao";
            this.lblInstAtual_NenhumaInstalacao.Size = new System.Drawing.Size(214, 18);
            this.lblInstAtual_NenhumaInstalacao.TabIndex = 8;
            this.lblInstAtual_NenhumaInstalacao.Text = "Nenhuma instalação detectada!";
            // 
            // lblInstAtual_Versao_Valor
            // 
            this.lblInstAtual_Versao_Valor.AutoSize = true;
            this.lblInstAtual_Versao_Valor.Location = new System.Drawing.Point(106, 144);
            this.lblInstAtual_Versao_Valor.Name = "lblInstAtual_Versao_Valor";
            this.lblInstAtual_Versao_Valor.Size = new System.Drawing.Size(31, 13);
            this.lblInstAtual_Versao_Valor.TabIndex = 7;
            this.lblInstAtual_Versao_Valor.Text = "1.0.0";
            // 
            // lblInstAtual_Versao
            // 
            this.lblInstAtual_Versao.AutoSize = true;
            this.lblInstAtual_Versao.Location = new System.Drawing.Point(57, 144);
            this.lblInstAtual_Versao.Name = "lblInstAtual_Versao";
            this.lblInstAtual_Versao.Size = new System.Drawing.Size(43, 13);
            this.lblInstAtual_Versao.TabIndex = 6;
            this.lblInstAtual_Versao.Text = "Versão:";
            // 
            // lblInstAtual_StatusServico_Valor
            // 
            this.lblInstAtual_StatusServico_Valor.AutoSize = true;
            this.lblInstAtual_StatusServico_Valor.Location = new System.Drawing.Point(106, 110);
            this.lblInstAtual_StatusServico_Valor.Name = "lblInstAtual_StatusServico_Valor";
            this.lblInstAtual_StatusServico_Valor.Size = new System.Drawing.Size(51, 13);
            this.lblInstAtual_StatusServico_Valor.TabIndex = 5;
            this.lblInstAtual_StatusServico_Valor.Text = "Rodando";
            // 
            // lblInstAtual_StatusServico
            // 
            this.lblInstAtual_StatusServico.AutoSize = true;
            this.lblInstAtual_StatusServico.Location = new System.Drawing.Point(10, 110);
            this.lblInstAtual_StatusServico.Name = "lblInstAtual_StatusServico";
            this.lblInstAtual_StatusServico.Size = new System.Drawing.Size(92, 13);
            this.lblInstAtual_StatusServico.TabIndex = 4;
            this.lblInstAtual_StatusServico.Text = "Status do serviço:";
            // 
            // lblInstAtual_NomeServico_Valor
            // 
            this.lblInstAtual_NomeServico_Valor.AutoSize = true;
            this.lblInstAtual_NomeServico_Valor.Location = new System.Drawing.Point(106, 73);
            this.lblInstAtual_NomeServico_Valor.Name = "lblInstAtual_NomeServico_Valor";
            this.lblInstAtual_NomeServico_Valor.Size = new System.Drawing.Size(97, 13);
            this.lblInstAtual_NomeServico_Valor.TabIndex = 3;
            this.lblInstAtual_NomeServico_Valor.Text = "Serviço Topshelf X";
            // 
            // lblInstAtual_NomeServico
            // 
            this.lblInstAtual_NomeServico.AutoSize = true;
            this.lblInstAtual_NomeServico.Location = new System.Drawing.Point(10, 73);
            this.lblInstAtual_NomeServico.Name = "lblInstAtual_NomeServico";
            this.lblInstAtual_NomeServico.Size = new System.Drawing.Size(90, 13);
            this.lblInstAtual_NomeServico.TabIndex = 2;
            this.lblInstAtual_NomeServico.Text = "Nome do serviço:";
            // 
            // lblInstAtual_Diretorio
            // 
            this.lblInstAtual_Diretorio.AutoSize = true;
            this.lblInstAtual_Diretorio.Location = new System.Drawing.Point(51, 41);
            this.lblInstAtual_Diretorio.Name = "lblInstAtual_Diretorio";
            this.lblInstAtual_Diretorio.Size = new System.Drawing.Size(49, 13);
            this.lblInstAtual_Diretorio.TabIndex = 0;
            this.lblInstAtual_Diretorio.Text = "Diretório:";
            // 
            // pnlWizard_1
            // 
            this.pnlWizard_1.BackColor = System.Drawing.Color.Transparent;
            this.pnlWizard_1.Controls.Add(this.btnSair);
            this.pnlWizard_1.Controls.Add(this.btnDesinstalar);
            this.pnlWizard_1.Controls.Add(this.button2);
            this.pnlWizard_1.Controls.Add(this.button1);
            this.pnlWizard_1.Location = new System.Drawing.Point(26, 274);
            this.pnlWizard_1.Name = "pnlWizard_1";
            this.pnlWizard_1.Size = new System.Drawing.Size(743, 181);
            this.pnlWizard_1.TabIndex = 3;
            // 
            // btnSair
            // 
            this.btnSair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSair.BackgroundImage")));
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(605, 20);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(138, 158);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "DESINSTALAR";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // btnDesinstalar
            // 
            this.btnDesinstalar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDesinstalar.BackgroundImage")));
            this.btnDesinstalar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDesinstalar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesinstalar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDesinstalar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesinstalar.Location = new System.Drawing.Point(318, 20);
            this.btnDesinstalar.Name = "btnDesinstalar";
            this.btnDesinstalar.Size = new System.Drawing.Size(138, 158);
            this.btnDesinstalar.TabIndex = 2;
            this.btnDesinstalar.Text = "ATUALIZAR";
            this.btnDesinstalar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDesinstalar.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(160, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 158);
            this.button2.TabIndex = 1;
            this.button2.Text = "REINSTALAR";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 158);
            this.button1.TabIndex = 0;
            this.button1.Text = "INSTALAR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.Color.Teal;
            this.lblCopyright.Location = new System.Drawing.Point(654, 475);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(129, 18);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "Copyright (c) 2018";
            // 
            // lnkSair
            // 
            this.lnkSair.AutoSize = true;
            this.lnkSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSair.LinkColor = System.Drawing.Color.Red;
            this.lnkSair.Location = new System.Drawing.Point(735, 0);
            this.lnkSair.Name = "lnkSair";
            this.lnkSair.Size = new System.Drawing.Size(38, 18);
            this.lnkSair.TabIndex = 5;
            this.lnkSair.TabStop = true;
            this.lnkSair.Text = "Sair";
            this.lnkSair.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSair_LinkClicked);
            // 
            // MainWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(795, 502);
            this.ControlBox = false;
            this.Controls.Add(this.lnkSair);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.pnlWizard_1);
            this.Controls.Add(this.gbxInstAtual);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.imgLogo);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWizardForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instalador do Serviço Topshelf X";
            this.Load += new System.EventHandler(this.MainWizardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.gbxInstAtual.ResumeLayout(false);
            this.gbxInstAtual.PerformLayout();
            this.pnlWizard_1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbxInstAtual;
        private System.Windows.Forms.Label lblInstAtual_StatusServico_Valor;
        private System.Windows.Forms.Label lblInstAtual_StatusServico;
        private System.Windows.Forms.Label lblInstAtual_NomeServico_Valor;
        private System.Windows.Forms.Label lblInstAtual_NomeServico;
        private System.Windows.Forms.Label lblInstAtual_Diretorio;
        private System.Windows.Forms.Label lblInstAtual_Versao_Valor;
        private System.Windows.Forms.Label lblInstAtual_Versao;
        private System.Windows.Forms.Label lblInstAtual_NenhumaInstalacao;
        private System.Windows.Forms.Panel pnlWizard_1;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.LinkLabel lblInstAtual_Diretorio_Valor;
        private System.Windows.Forms.LinkLabel lnkSair;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDesinstalar;
        private System.Windows.Forms.Button btnSair;
    }
}

