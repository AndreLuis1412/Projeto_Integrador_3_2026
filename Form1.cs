using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Draft;

namespace PI_3___2026
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblVersaoDLL.Text = "Versão: " + Jogo.versao;
            lblNomeGrupo.Text = "Nome do Grupo: Fossilistas";
        }

        private void InitializeComponent()
        {
            this.btnListarPartidas = new System.Windows.Forms.Button();
            this.lstListaPartidas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVersaoDLL = new System.Windows.Forms.Label();
            this.txtIdPartida = new System.Windows.Forms.TextBox();
            this.txtNomePartida = new System.Windows.Forms.TextBox();
            this.txtDataPartida = new System.Windows.Forms.TextBox();
            this.lblNomeGrupo = new System.Windows.Forms.Label();
            this.lstExibeJogadores = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnListarPartidas
            // 
            this.btnListarPartidas.Location = new System.Drawing.Point(21, 17);
            this.btnListarPartidas.Name = "btnListarPartidas";
            this.btnListarPartidas.Size = new System.Drawing.Size(116, 23);
            this.btnListarPartidas.TabIndex = 0;
            this.btnListarPartidas.Text = "Listar Partidas";
            this.btnListarPartidas.UseVisualStyleBackColor = true;
            this.btnListarPartidas.Click += new System.EventHandler(this.btnListarPartidas_Click);
            // 
            // lstListaPartidas
            // 
            this.lstListaPartidas.FormattingEnabled = true;
            this.lstListaPartidas.ItemHeight = 16;
            this.lstListaPartidas.Location = new System.Drawing.Point(21, 46);
            this.lstListaPartidas.Name = "lstListaPartidas";
            this.lstListaPartidas.Size = new System.Drawing.Size(223, 308);
            this.lstListaPartidas.TabIndex = 2;
            this.lstListaPartidas.SelectedIndexChanged += new System.EventHandler(this.lstListaPartidas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID Partida:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome Partida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Partida:";
            // 
            // lblVersaoDLL
            // 
            this.lblVersaoDLL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersaoDLL.AutoSize = true;
            this.lblVersaoDLL.Location = new System.Drawing.Point(3, 479);
            this.lblVersaoDLL.Name = "lblVersaoDLL";
            this.lblVersaoDLL.Size = new System.Drawing.Size(0, 16);
            this.lblVersaoDLL.TabIndex = 6;
            // 
            // txtIdPartida
            // 
            this.txtIdPartida.Location = new System.Drawing.Point(339, 40);
            this.txtIdPartida.Name = "txtIdPartida";
            this.txtIdPartida.Size = new System.Drawing.Size(50, 22);
            this.txtIdPartida.TabIndex = 7;
            // 
            // txtNomePartida
            // 
            this.txtNomePartida.Location = new System.Drawing.Point(363, 81);
            this.txtNomePartida.Name = "txtNomePartida";
            this.txtNomePartida.Size = new System.Drawing.Size(153, 22);
            this.txtNomePartida.TabIndex = 8;
            // 
            // txtDataPartida
            // 
            this.txtDataPartida.Location = new System.Drawing.Point(363, 114);
            this.txtDataPartida.Name = "txtDataPartida";
            this.txtDataPartida.Size = new System.Drawing.Size(93, 22);
            this.txtDataPartida.TabIndex = 9;
            // 
            // lblNomeGrupo
            // 
            this.lblNomeGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNomeGrupo.AutoSize = true;
            this.lblNomeGrupo.Location = new System.Drawing.Point(3, 463);
            this.lblNomeGrupo.Name = "lblNomeGrupo";
            this.lblNomeGrupo.Size = new System.Drawing.Size(0, 16);
            this.lblNomeGrupo.TabIndex = 10;
            // 
            // lstExibeJogadores
            // 
            this.lstExibeJogadores.FormattingEnabled = true;
            this.lstExibeJogadores.ItemHeight = 16;
            this.lstExibeJogadores.Location = new System.Drawing.Point(267, 190);
            this.lstExibeJogadores.Name = "lstExibeJogadores";
            this.lstExibeJogadores.Size = new System.Drawing.Size(238, 164);
            this.lstExibeJogadores.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Jogadores:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(912, 504);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstExibeJogadores);
            this.Controls.Add(this.lblNomeGrupo);
            this.Controls.Add(this.txtDataPartida);
            this.Controls.Add(this.txtNomePartida);
            this.Controls.Add(this.txtIdPartida);
            this.Controls.Add(this.lblVersaoDLL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstListaPartidas);
            this.Controls.Add(this.btnListarPartidas);
            this.MinimumSize = new System.Drawing.Size(930, 550);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            
        }

        public bool VerifyScreen()
        {
            if (Jogo.versao == "2") //Adaptar para futuros erros
            {
                MessageBox.Show("Erro");
                return false;
            }

            return true;
        }

        private void btnListarPartidas_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ListarPartidas("T");
            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);

            string[] partidas = retorno.Split('\n');
            lstListaPartidas.Items.Clear();
            for (int i = 0; i < partidas.Length - 1; i++)
            {
                lstListaPartidas.Items.Add(partidas[i]);
            }
        }

        private void lstListaPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ao selecionar um item da lista, pegamos seus dados e passamos para variáveis
            string partida = lstListaPartidas.SelectedItem.ToString();
            string[] dadosPartida = partida.Split(',');

            int idPartida = Convert.ToInt32(dadosPartida[0]);
            string nomePartida = dadosPartida[1];
            string dataPartida = dadosPartida[2];

            txtIdPartida.Text = idPartida.ToString();
            txtIdPartida.Text = nomePartida;
            txtIdPartida.Text = dataPartida;

            //Exibimos tbm em outra lst, a lista de jogadores que estão na partida selecionada
            string retornoJogadores = Jogo.ListarJogadores(idPartida);
            //Tratando possiveis erros (usar de base para generalizar todos os erros)
            if(retornoJogadores.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retornoJogadores.Substring(5, retornoJogadores.Length), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            retornoJogadores = retornoJogadores.Replace("\r", "");
            retornoJogadores = retornoJogadores.Substring(0, retornoJogadores.Length - 1);

            string[] jogadores = retornoJogadores.Split('\n');
            lstExibeJogadores.Items.Clear();
            for (int i = 0; i < jogadores.Length - 1; i++)
            {
                lstExibeJogadores.Items.Add(jogadores[i]);
            }

        }
    }
}
