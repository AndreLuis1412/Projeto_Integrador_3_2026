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
            this.btnCriarPartida = new System.Windows.Forms.Button();
            this.txtNomeCriarPartida = new System.Windows.Forms.TextBox();
            this.txtSenhaPartida = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEntrarPartida = new System.Windows.Forms.Button();
            this.txtNomeJogador = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSenhaJogador = new System.Windows.Forms.TextBox();
            this.lstDinossauros = new System.Windows.Forms.ListBox();
            this.btnExibirDino = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdJogador = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtJogadorDaVez = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFaceDado = new System.Windows.Forms.TextBox();
            this.txtDinoJogar = new System.Windows.Forms.TextBox();
            this.txtCercadoJogar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnJogar = new System.Windows.Forms.Button();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnVerificarPartida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnListarPartidas
            // 
            this.btnListarPartidas.Location = new System.Drawing.Point(19, 15);
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
            this.lstListaPartidas.Location = new System.Drawing.Point(19, 44);
            this.lstListaPartidas.Name = "lstListaPartidas";
            this.lstListaPartidas.Size = new System.Drawing.Size(223, 308);
            this.lstListaPartidas.TabIndex = 2;
            this.lstListaPartidas.SelectedIndexChanged += new System.EventHandler(this.lstListaPartidas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID Partida:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome Partida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Partida:";
            // 
            // lblVersaoDLL
            // 
            this.lblVersaoDLL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersaoDLL.AutoSize = true;
            this.lblVersaoDLL.Location = new System.Drawing.Point(3, 635);
            this.lblVersaoDLL.Name = "lblVersaoDLL";
            this.lblVersaoDLL.Size = new System.Drawing.Size(0, 16);
            this.lblVersaoDLL.TabIndex = 6;
            // 
            // txtIdPartida
            // 
            this.txtIdPartida.Location = new System.Drawing.Point(337, 38);
            this.txtIdPartida.Name = "txtIdPartida";
            this.txtIdPartida.Size = new System.Drawing.Size(50, 22);
            this.txtIdPartida.TabIndex = 7;
            // 
            // txtNomePartida
            // 
            this.txtNomePartida.Location = new System.Drawing.Point(361, 79);
            this.txtNomePartida.Name = "txtNomePartida";
            this.txtNomePartida.Size = new System.Drawing.Size(153, 22);
            this.txtNomePartida.TabIndex = 8;
            // 
            // txtDataPartida
            // 
            this.txtDataPartida.Location = new System.Drawing.Point(361, 112);
            this.txtDataPartida.Name = "txtDataPartida";
            this.txtDataPartida.Size = new System.Drawing.Size(93, 22);
            this.txtDataPartida.TabIndex = 9;
            // 
            // lblNomeGrupo
            // 
            this.lblNomeGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNomeGrupo.AutoSize = true;
            this.lblNomeGrupo.Location = new System.Drawing.Point(3, 619);
            this.lblNomeGrupo.Name = "lblNomeGrupo";
            this.lblNomeGrupo.Size = new System.Drawing.Size(0, 16);
            this.lblNomeGrupo.TabIndex = 10;
            // 
            // lstExibeJogadores
            // 
            this.lstExibeJogadores.FormattingEnabled = true;
            this.lstExibeJogadores.ItemHeight = 16;
            this.lstExibeJogadores.Location = new System.Drawing.Point(265, 188);
            this.lstExibeJogadores.Name = "lstExibeJogadores";
            this.lstExibeJogadores.Size = new System.Drawing.Size(238, 164);
            this.lstExibeJogadores.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Jogadores:";
            // 
            // btnCriarPartida
            // 
            this.btnCriarPartida.Location = new System.Drawing.Point(524, 273);
            this.btnCriarPartida.Name = "btnCriarPartida";
            this.btnCriarPartida.Size = new System.Drawing.Size(90, 23);
            this.btnCriarPartida.TabIndex = 13;
            this.btnCriarPartida.Text = "Criar Partida";
            this.btnCriarPartida.UseVisualStyleBackColor = true;
            this.btnCriarPartida.Click += new System.EventHandler(this.btnCriarPartida_Click);
            // 
            // txtNomeCriarPartida
            // 
            this.txtNomeCriarPartida.Location = new System.Drawing.Point(633, 197);
            this.txtNomeCriarPartida.Name = "txtNomeCriarPartida";
            this.txtNomeCriarPartida.Size = new System.Drawing.Size(139, 22);
            this.txtNomeCriarPartida.TabIndex = 14;
            // 
            // txtSenhaPartida
            // 
            this.txtSenhaPartida.Location = new System.Drawing.Point(631, 233);
            this.txtSenhaPartida.Name = "txtSenhaPartida";
            this.txtSenhaPartida.Size = new System.Drawing.Size(141, 22);
            this.txtSenhaPartida.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Nome da Partida:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(511, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Senha da Partida:";
            // 
            // btnEntrarPartida
            // 
            this.btnEntrarPartida.Location = new System.Drawing.Point(673, 139);
            this.btnEntrarPartida.Name = "btnEntrarPartida";
            this.btnEntrarPartida.Size = new System.Drawing.Size(119, 23);
            this.btnEntrarPartida.TabIndex = 20;
            this.btnEntrarPartida.Text = "Entrar na Partida";
            this.btnEntrarPartida.UseVisualStyleBackColor = true;
            this.btnEntrarPartida.Click += new System.EventHandler(this.btnEntrarPartida_Click);
            // 
            // txtNomeJogador
            // 
            this.txtNomeJogador.Location = new System.Drawing.Point(663, 34);
            this.txtNomeJogador.Name = "txtNomeJogador";
            this.txtNomeJogador.Size = new System.Drawing.Size(129, 22);
            this.txtNomeJogador.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(560, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Nome Jogador:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(560, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Senha Jogador:";
            // 
            // txtSenhaJogador
            // 
            this.txtSenhaJogador.Location = new System.Drawing.Point(663, 66);
            this.txtSenhaJogador.Name = "txtSenhaJogador";
            this.txtSenhaJogador.Size = new System.Drawing.Size(129, 22);
            this.txtSenhaJogador.TabIndex = 24;
            // 
            // lstDinossauros
            // 
            this.lstDinossauros.FormattingEnabled = true;
            this.lstDinossauros.ItemHeight = 16;
            this.lstDinossauros.Location = new System.Drawing.Point(19, 381);
            this.lstDinossauros.Name = "lstDinossauros";
            this.lstDinossauros.Size = new System.Drawing.Size(223, 196);
            this.lstDinossauros.TabIndex = 25;
            // 
            // btnExibirDino
            // 
            this.btnExibirDino.Location = new System.Drawing.Point(19, 583);
            this.btnExibirDino.Name = "btnExibirDino";
            this.btnExibirDino.Size = new System.Drawing.Size(133, 23);
            this.btnExibirDino.TabIndex = 26;
            this.btnExibirDino.Text = "Exibir Dinossauros";
            this.btnExibirDino.UseVisualStyleBackColor = true;
            this.btnExibirDino.Click += new System.EventHandler(this.btnExibirDino_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "Dinossauros disponíveis:";
            // 
            // txtIdJogador
            // 
            this.txtIdJogador.Location = new System.Drawing.Point(663, 94);
            this.txtIdJogador.Name = "txtIdJogador";
            this.txtIdJogador.Size = new System.Drawing.Size(129, 22);
            this.txtIdJogador.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(584, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "ID Jogador:";
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Location = new System.Drawing.Point(694, 273);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(98, 23);
            this.btnIniciarPartida.TabIndex = 30;
            this.btnIniciarPartida.Text = "Iniciar Partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(529, 440);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "Vez de:";
            // 
            // txtJogadorDaVez
            // 
            this.txtJogadorDaVez.Location = new System.Drawing.Point(587, 434);
            this.txtJogadorDaVez.Name = "txtJogadorDaVez";
            this.txtJogadorDaVez.Size = new System.Drawing.Size(139, 22);
            this.txtJogadorDaVez.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(506, 462);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 16);
            this.label13.TabIndex = 34;
            this.label13.Text = "Face Dado:";
            // 
            // txtFaceDado
            // 
            this.txtFaceDado.Location = new System.Drawing.Point(587, 458);
            this.txtFaceDado.Name = "txtFaceDado";
            this.txtFaceDado.Size = new System.Drawing.Size(58, 22);
            this.txtFaceDado.TabIndex = 33;
            // 
            // txtDinoJogar
            // 
            this.txtDinoJogar.Location = new System.Drawing.Point(361, 416);
            this.txtDinoJogar.Name = "txtDinoJogar";
            this.txtDinoJogar.Size = new System.Drawing.Size(69, 22);
            this.txtDinoJogar.TabIndex = 35;
            // 
            // txtCercadoJogar
            // 
            this.txtCercadoJogar.Location = new System.Drawing.Point(361, 444);
            this.txtCercadoJogar.Name = "txtCercadoJogar";
            this.txtCercadoJogar.Size = new System.Drawing.Size(69, 22);
            this.txtCercadoJogar.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Dinossauro:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(293, 448);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 16);
            this.label14.TabIndex = 38;
            this.label14.Text = "Cercado:";
            // 
            // btnJogar
            // 
            this.btnJogar.Location = new System.Drawing.Point(283, 472);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(80, 26);
            this.btnJogar.TabIndex = 39;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = true;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(587, 413);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.Size = new System.Drawing.Size(50, 22);
            this.txtTurno.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(538, 416);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 16);
            this.label15.TabIndex = 40;
            this.label15.Text = "Turno:";
            // 
            // btnVerificarPartida
            // 
            this.btnVerificarPartida.Location = new System.Drawing.Point(587, 482);
            this.btnVerificarPartida.Name = "btnVerificarPartida";
            this.btnVerificarPartida.Size = new System.Drawing.Size(119, 23);
            this.btnVerificarPartida.TabIndex = 43;
            this.btnVerificarPartida.Text = "Verificar Partida";
            this.btnVerificarPartida.UseVisualStyleBackColor = true;
            this.btnVerificarPartida.Click += new System.EventHandler(this.btnVerificarPartida_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(934, 660);
            this.Controls.Add(this.btnVerificarPartida);
            this.Controls.Add(this.txtTurno);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCercadoJogar);
            this.Controls.Add(this.txtDinoJogar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtFaceDado);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtJogadorDaVez);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.txtIdJogador);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnExibirDino);
            this.Controls.Add(this.lstDinossauros);
            this.Controls.Add(this.txtSenhaJogador);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNomeJogador);
            this.Controls.Add(this.btnEntrarPartida);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSenhaPartida);
            this.Controls.Add(this.txtNomeCriarPartida);
            this.Controls.Add(this.btnCriarPartida);
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
            this.MinimumSize = new System.Drawing.Size(952, 707);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            
        }

        bool verificarJogada(string faceDado, string campoJogada)
        {
            if (faceDado == "AL" && (campoJogada == "" ||))
                return true;
            else if (faceDado == "FL" && (campoJogada == "" ||))
                return true;
            else if (faceDado == "PR" && (campoJogada == "" ||))
                return true;
            else if (faceDado == "TI" && (campoJogada == "" ||))
                return true;
            else if ((faceDado == "VZ" && (campoJogada == "" ||))
                return true;
            else if ((faceDado == "WC" && (campoJogada == "" ||))
                return true;
            return false;
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
            for (int i = 0; i < partidas.Length; i++)
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
            txtNomePartida.Text = nomePartida;
            txtDataPartida.Text = dataPartida;

            //Exibimos tbm em outra lst, a lista de jogadores que estão na partida selecionada
            string retornoJogadores = Jogo.ListarJogadores(idPartida);
            //Tratando possiveis erros (usar de base para generalizar todos os erros)
            if(retornoJogadores.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retornoJogadores.Substring(5), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                retornoJogadores = retornoJogadores.Replace("\r", "");
                retornoJogadores = retornoJogadores.Substring(0, retornoJogadores.Length - 1);

                string[] jogadores = retornoJogadores.Split('\n');
                lstExibeJogadores.Items.Clear();
                for (int i = 0; i < jogadores.Length; i++)
                {
                    lstExibeJogadores.Items.Add(jogadores[i]);
                }
            }
        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            txtIdPartida.Clear();
            txtNomePartida.Clear();
            txtDataPartida.Clear();

            string nomePartida = txtNomeCriarPartida.Text;
            string senhaPartida = txtSenhaPartida.Text;


            string retornoCriarPartida = Jogo.CriarPartida(nomePartida, senhaPartida, "Fossilistas");
            if(retornoCriarPartida.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retornoCriarPartida.Substring(5), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtIdPartida.Text = retornoCriarPartida;
                int IdPartida = Convert.ToInt32(retornoCriarPartida);

                string retorno = Jogo.ListarPartidas("T");
                retorno = retorno.Replace("\r", "");
                retorno = retorno.Substring(0, retorno.Length - 1);

                string[] partidas = retorno.Split('\n');
                lstListaPartidas.Items.Clear();
                for (int i = 0; i < partidas.Length; i++)
                {
                    lstListaPartidas.Items.Add(partidas[i]);
                }
            }
        }

        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            int idPartidaEntrar = Convert.ToInt32(txtIdPartida.Text);
            string nomeJogador = txtNomeJogador.Text;
            string senhaPartida = txtSenhaPartida.Text;

            string retornoEntrar = Jogo.Entrar(idPartidaEntrar, nomeJogador, senhaPartida);

            if(retornoEntrar.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retornoEntrar.Substring(5), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                retornoEntrar = retornoEntrar.Replace("\r", "");
                string[] jogador = retornoEntrar.Split(',');

                txtIdJogador.Text = jogador[0];
                txtSenhaJogador.Text = jogador[1];
            }
        }

        private void btnExibirDino_Click(object sender, EventArgs e)
        {
            int idJogador = Convert.ToInt32(txtIdJogador.Text);
            string senhaJogador = txtSenhaJogador.Text;

            string retornoDino = Jogo.ExibirMao(idJogador, senhaJogador);

            if(retornoDino.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retornoDino.Substring(5), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                retornoDino = retornoDino.Replace("\r", "");
                retornoDino = retornoDino.Substring(0, retornoDino.Length - 1);

                string[] dinos = retornoDino.Split('\n');
                lstDinossauros.Items.Clear();
                for (int i = 0; i < dinos.Length; i++)
                {
                    lstDinossauros.Items.Add(dinos[i]);
                }
            }
        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            int idJogador = Convert.ToInt32(txtIdJogador.Text);
            string senhaJogador = txtSenhaJogador.Text;

            string retornoIniciar = Jogo.Iniciar(idJogador, senhaJogador);

            if(retornoIniciar.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retornoIniciar.Substring(5), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string[] jodagoDado = retornoIniciar.Split(',');
                txtJogadorDaVez.Text = jodagoDado[0];
                txtFaceDado.Text = jodagoDado[1];
            }
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            int idJogador = Convert.ToInt32(txtIdJogador.Text);
            string senhaJogador = txtSenhaJogador.Text;
            string dino = txtDinoJogar.Text;
            string cercado = txtCercadoJogar.Text;

            string retornoJogar = Jogo.Jogar(idJogador, senhaJogador, dino, cercado);
            int retornoJoga = Convert.ToInt32(retornoJogar);
        }

        private void btnVerificarPartida_Click(object sender, EventArgs e)
        {
            int idPartida = Convert.ToInt32(txtIdPartida.Text);

            string retornoVerPartida = Jogo.VerificarPartida(idPartida);

            retornoVerPartida = retornoVerPartida.Replace("\r", "");
            retornoVerPartida = retornoVerPartida.Substring(0, retornoVerPartida.Length - 1);

            string[] verPartida = retornoVerPartida.Split(',');

            string turno = verPartida[1];
            string jogadorDaVez = verPartida[3];
            string faceDado = verPartida[4];

            txtTurno.Clear();
            txtJogadorDaVez.Clear();
            txtFaceDado.Clear();

            txtTurno.Text = turno;
            txtJogadorDaVez.Text = jogadorDaVez;
            txtFaceDado.Text = faceDado;
        }
    }
}