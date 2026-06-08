using Draft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PI_3___2026
{
    public partial class Form1 : Form
    {
        Partida p = new Partida();
        Jogador jogador;
        Tabuleiro formTabuleiro;

        private string turnoAnterior = "-1";

        Dictionary<string, string> facesDadoDict = new Dictionary<string, string>()
        {
            { "AL", "Alimentação" },
            { "FL", "Floresta" },
            { "PR", "Pradaria" },
            { "TI", "Tiranossauro Rex" },
            { "VZ", "Cercado Vazio" },
            { "WC", "Banheiros" }
        };

        public Form1()
        {
            InitializeComponent();
            lblVersaoDLL.Text = "Versão: " + Jogo.versao;
            lblNomeGrupo.Text = "Nome do Grupo: Fossilistas";
        }

        private void btnListarPartidas_Click(object sender, EventArgs e)
        {
            List<Partida> partidas = Partida.ListarPartidas();
            lstListaPartidas.Items.Clear();
            foreach (Partida partida in partidas)
                lstListaPartidas.Items.Add(partida);
        }

        private void lstListaPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(lstListaPartidas.SelectedItem is Partida partidaSelecionada))
                return;

            txtIdPartida.Text = partidaSelecionada.Id.ToString();
            txtNomePartida.Text = partidaSelecionada.Nome;
            txtDataPartida.Text = partidaSelecionada.DataCriacao;

            p = partidaSelecionada;

            List<Jogador> jogadores = partidaSelecionada.ListarJogadores();
            lstExibeJogadores.Items.Clear();
            foreach (Jogador j in jogadores)
                lstExibeJogadores.Items.Add(j);
        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            string nomePartida = txtNomeCriarPartida.Text;
            string senhaPartida = txtSenhaPartida.Text;

            Partida novaPartida = Partida.CriarPartida(nomePartida, senhaPartida);
            if (novaPartida == null) return;

            p = novaPartida;
            txtIdPartida.Text = p.Id.ToString();
            txtNomePartida.Text = p.Nome;
            txtDataPartida.Clear();

            List<Partida> partidas = Partida.ListarPartidas();
            lstListaPartidas.Items.Clear();
            foreach (Partida partida in partidas)
                lstListaPartidas.Items.Add(partida);
        }

        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdPartida.Text, out int idPartidaEntrar))
            {
                MessageBox.Show("ID da partida inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomeJogador = txtNomeJogador.Text;
            string senhaPartida = txtSenhaPartida.Text;

            jogador = p.EntrarPartida(idPartidaEntrar, nomeJogador, senhaPartida);
            if (jogador == null) return;

            txtIdJogador.Text = jogador.Id.ToString();
            txtSenhaJogador.Text = jogador.Senha;
        }

        private void btnExibirDino_Click(object sender, EventArgs e)
        {
            if (jogador == null) return;

            if (!int.TryParse(txtIdJogador.Text, out int idJogador)) return;
            string senhaJogador = txtSenhaJogador.Text;

            string retornoDino = Jogo.ExibirMao(idJogador, senhaJogador);

            if (string.IsNullOrEmpty(retornoDino) || retornoDino.StartsWith("ER"))
                return;

            retornoDino = retornoDino.Replace("\r", "").Trim();

            if (retornoDino.Length > 1)
                retornoDino = retornoDino.Substring(1);

            string[] dinos = retornoDino.Split('\n');

            lstDinossauros.Items.Clear();
            jogador.dinossauros.Clear();

            foreach (string linha in dinos)
            {
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] partes = linha.Split(',');
                if (partes.Length < 2) continue;

                string codDino = partes[0].Trim();
                if (!int.TryParse(partes[1].Trim(), out int quantidade)) continue;

                lstDinossauros.Items.Add($"{codDino} x{quantidade}");

                for (int j = 0; j < quantidade; j++)
                    jogador.dinossauros.Add(codDino);
            }
        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            if (jogador == null) return;

            if (!int.TryParse(txtIdJogador.Text, out int idJogador)) return;
            string senhaJogador = txtSenhaJogador.Text;

            string retornoIniciar = Jogo.Iniciar(idJogador, senhaJogador);

            if (string.IsNullOrEmpty(retornoIniciar) || retornoIniciar.StartsWith("ER"))
            {
                string msg = retornoIniciar?.Length > 5 ? retornoIniciar.Substring(5) : retornoIniciar;
                MessageBox.Show("Ocorreu um erro:\n" + msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] dadosIniciar = retornoIniciar.Split(',');
            if (dadosIniciar.Length >= 2)
            {
                txtJogadorDaVez.Text = dadosIniciar[0];
                txtFaceDado.Text = dadosIniciar.Length > 1 ? dadosIniciar[1] : "";
            }
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            if (jogador == null) return;

            if (!int.TryParse(txtIdJogador.Text, out int idJogador)) return;
            string senhaJogador = txtSenhaJogador.Text;
            string dino = txtDinoJogar.Text;
            string cercado = txtCercadoJogar.Text;

            string retornoJogar = Jogo.Jogar(idJogador, senhaJogador, dino, cercado);

            if (string.IsNullOrEmpty(retornoJogar) || retornoJogar.StartsWith("ER"))
            {
                string msg = retornoJogar?.Length > 5 ? retornoJogar.Substring(5) : retornoJogar;
                MessageBox.Show("Ocorreu um erro:\n" + msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVerificarPartida_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdPartida.Text, out int idPartida)) return;

            Dictionary<int, string> jogadoresDict = ObterDicionarioJogadores(idPartida);
            if (jogadoresDict == null) return;

            string retorno = Jogo.VerificarPartida(idPartida);
            if (string.IsNullOrEmpty(retorno) || retorno.StartsWith("ER")) return;

            try
            {
                retorno = retorno.Replace("\r", "").TrimEnd('\n');
                string[] dados = retorno.Split(',');

                if (dados.Length < 5) return;

                string turno = dados[1];
                int idJogadorDaVez = Convert.ToInt32(dados[3]);
                string codFace = dados[4].Length >= 2 ? dados[4].Substring(0, 2) : dados[4];

                txtTurno.Text = turno;
                txtJogadorDaVez.Text = jogadoresDict.ContainsKey(idJogadorDaVez)
                    ? jogadoresDict[idJogadorDaVez]
                    : idJogadorDaVez.ToString();
                txtFaceDado.Text = facesDadoDict.ContainsKey(codFace)
                    ? facesDadoDict[codFace]
                    : codFace;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar partida:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerificarTurno_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdPartida.Text, out int idPartida)) return;

            string retorno = Jogo.VerificarTurno(idPartida);

            if (string.IsNullOrEmpty(retorno) || retorno.StartsWith("ER"))
            {
                string msg = retorno?.Length > 5 ? retorno.Substring(5) : retorno;
                MessageBox.Show("Ocorreu um erro:\n" + msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dictionary<int, string> jogadoresDict = ObterDicionarioJogadores(idPartida);
            if (jogadoresDict == null) return;

            try
            {
                retorno = retorno.Replace("\r", "").TrimEnd('\n');
                string[] dados = retorno.Split(',');

                if (dados.Length < 3) return;

                int idJogadorDaVez = Convert.ToInt32(dados[1]);
                string codFace = dados[2].Length >= 2 ? dados[2].Substring(0, 2) : dados[2];

                txtJogadorDaVez.Text = jogadoresDict.ContainsKey(idJogadorDaVez)
                    ? jogadoresDict[idJogadorDaVez]
                    : idJogadorDaVez.ToString();
                txtFaceDado.Text = facesDadoDict.ContainsKey(codFace)
                    ? facesDadoDict[codFace]
                    : codFace;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar turno:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIniciarAgente_Click(object sender, EventArgs e)
        {
            if (formTabuleiro == null || formTabuleiro.IsDisposed)
            {
                formTabuleiro = new Tabuleiro();
                formTabuleiro.Show();
            }

            btnExibirDino_Click(sender, e);
            btnVerificarPartida_Click(sender, e);
            tmrVerificarPartida.Enabled = true;
        }

        private Dictionary<int, string> ObterDicionarioJogadores(int idPartida)
        {
            string retorno = Jogo.ListarJogadores(idPartida);

            if (string.IsNullOrEmpty(retorno) || retorno.StartsWith("ER"))
                return null;

            var dict = new Dictionary<int, string>();

            try
            {
                retorno = retorno.Replace("\r", "").TrimEnd('\n');
                string[] linhas = retorno.Split('\n');

                foreach (string linha in linhas)
                {
                    if (string.IsNullOrWhiteSpace(linha)) continue;
                    string[] partes = linha.Split(',');
                    if (partes.Length < 2) continue;

                    if (int.TryParse(partes[0].Trim(), out int id))
                        dict[id] = partes[1].Trim();
                }
            }
            catch { return null; }

            return dict;
        }

        private void tmrVerificarPartida_Tick(object sender, EventArgs e)
        {
            tmrVerificarPartida.Enabled = false;
            lblTestTimer.Text = "Tempo: " + DateTime.Now.ToString("HH:mm:ss");

            btnVerificarPartida_Click(sender, e);

            string turnoAtual = txtTurno.Text;

            if (turnoAtual == "13" || DinosNoTabuleiro() >= 12)
            {
                lblTestTimer.Text = "Jogo encerrado!";
                return; 
            }

            if (string.IsNullOrWhiteSpace(turnoAtual) || turnoAtual == turnoAnterior)
            {
                tmrVerificarPartida.Enabled = true;
                return;
            }

            turnoAnterior = turnoAtual;

            if (jogador != null)
            {
                btnExibirDino_Click(sender, e);

                if (jogador.dinossauros.Count > 0)
                {
                    ExecutarEstrategia();
                    btnExibirDino_Click(sender, e);
                }
            }

            tmrVerificarPartida.Enabled = true;
        }

        private int DinosNoTabuleiro()
            => p.tabuleiro.Values.Sum(lista => lista.Count);

        private void ExecutarEstrategia()
        {
            if (jogador == null || jogador.dinossauros.Count == 0) return;

            string faceDado = txtFaceDado.Text;
            string dino = null;
            string cercado = null;

            switch (faceDado)
            {
                case "Floresta":
                    (dino, cercado) = EstrategiaRestricaoFloresta();
                    break;
                case "Alimentação":
                    (dino, cercado) = EstrategiaRestricaoAlimentacao();
                    break;
                case "Pradaria":
                    (dino, cercado) = EstrategiaRestricaoPradaria();
                    break;
                case "Banheiros":
                    (dino, cercado) = EstrategiaRestricaoBanheiros();
                    break;
                case "Cercado Vazio":
                    (dino, cercado) = EstrategiaRestricaoCercadoVazio();
                    break;
                case "Tiranossauro Rex":
                    (dino, cercado) = EstrategiaRestricaoSemRex();
                    break;
                default:
                    (dino, cercado) = MelhorJogadaGeral();
                    break;
            }

            if (dino == null || cercado == null)
                (dino, cercado) = JogadaSegura();

            if (dino != null && cercado != null)
            {
                lblDinoEscolhido.Text = "Dino Escolhido: " + dino;
                lblCampoEscolhido.Text = "Campo Escolhido: " + cercado;

                bool sucesso = jogador.Jogar(dino, cercado);
                if (sucesso)
                {
                    if (p.tabuleiro.ContainsKey(cercado))
                        p.tabuleiro[cercado].Add(dino);

                    if (formTabuleiro != null && !formTabuleiro.IsDisposed)
                        formTabuleiro.AtualizarTabuleiro(p.tabuleiro);

                    jogador.dinossauros.Remove(dino);
                }
                else
                {
                    MessageBox.Show($"Falha ao jogar {dino} em {cercado}.", "Estratégia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private (string dino, string cercado) EstrategiaRestricaoFloresta()
            => EscolherMelhorJogadaEntre(new List<string> { "FI", "MT", "RS", "RI"});
        private (string dino, string cercado) EstrategiaRestricaoAlimentacao()
            => EscolherMelhorJogadaEntre(new List<string> { "FI", "MT", "PA", "RI" });
        private (string dino, string cercado) EstrategiaRestricaoPradaria()
            => EscolherMelhorJogadaEntre(new List<string> { "PA", "CD", "IS", "RI"});
        private (string dino, string cercado) EstrategiaRestricaoBanheiros()
            => EscolherMelhorJogadaEntre(new List<string> { "IS", "CD", "RS", "RI"});
        private (string dino, string cercado) EstrategiaRestricaoCercadoVazio()
        {
            var vazios = p.tabuleiro
                .Where(kvp => kvp.Value.Count == 0)
                .Select(kvp => kvp.Key)
                .ToList();

            return vazios.Count > 0
                ? EscolherMelhorJogadaEntre(vazios)
                : JogadaSegura();
        }
        private (string dino, string cercado) EstrategiaRestricaoSemRex()
        {
            var semRex = p.tabuleiro
                .Where(kvp => !kvp.Value.Contains("Ti"))
                .Select(kvp => kvp.Key)
                .ToList();

            return semRex.Count > 0
                ? EscolherMelhorJogadaEntre(semRex)
                : JogadaSegura();
        }

        private (string dino, string cercado) EscolherMelhorJogadaEntre(List<string> cercadosPermitidos)
        {
            string melhorDino = null;
            string melhorCercado = null;
            int melhorGanho = -999;

            foreach (string codCercado in cercadosPermitidos)
            {
                if (!p.tabuleiro.ContainsKey(codCercado)) continue;

                foreach (string codDino in jogador.dinossauros.Distinct())
                {
                    int ganho = AvaliarGanho(codDino, codCercado);
                    if (ganho > melhorGanho)
                    {
                        melhorGanho = ganho;
                        melhorDino = codDino;
                        melhorCercado = codCercado;
                    }
                }
            }

            return (melhorDino, melhorCercado);
        }

        private int AvaliarGanho(string codDino, string codCercado)
        {
            var cercado = p.tabuleiro[codCercado];
            int qtdAtual = cercado.Count;

            switch (codCercado)
            {
                case "FI":
                    {
                        if (qtdAtual > 0 && cercado[0] != codDino) return -999; 
                        if (qtdAtual >= 6) return -999; 

                        int[] tabela = { 0, 2, 4, 8, 12, 18, 24 };
                        int ganho = tabela[qtdAtual + 1] - tabela[qtdAtual];
                        if (codDino == "Ti") ganho += 1; 
                        return ganho;
                    }

                case "CD": 
                    {
                        if (cercado.Contains(codDino)) return -999; 
                        if (qtdAtual >= 6) return -999; 

                        int[] tabela = { 0, 1, 3, 6, 10, 15, 21 };
                        int ganho = tabela[qtdAtual + 1] - tabela[qtdAtual];
                        if (codDino == "Ti") ganho += 1;
                        return ganho;
                    }

                case "PA":
                    {
                        int mesmosNoPA = cercado.Count(d => d == codDino);
                        int ganho = (mesmosNoPA % 2 == 1) ? 5 : 1;
                        if (codDino == "Ti") ganho += 1;
                        return ganho;
                    }

                case "MT":
                    {
                        if (qtdAtual >= 3) return -999; 

                        int ganho = (qtdAtual == 2) ? 7 : 2; 
                        if (codDino == "Ti") ganho += 1;
                        return ganho;
                    }

                case "RS":
                    {
                        if (qtdAtual >= 1) return -999; 

                        int totalNoZoo = ContarDinoNoZoo(codDino) + 1;
                        int ganho = totalNoZoo * 2; 
                        if (codDino == "Ti") ganho += 1;
                        return ganho;
                    }

                case "IS":
                    {
                        if (qtdAtual >= 1) return -999; 

                        bool unicoNoZoo = ContarDinoNoZoo(codDino) == 0;
                        if (unicoNoZoo)
                        {
                            int ganho = 7;
                            if (codDino == "Ti") ganho += 1;
                            return ganho;
                        }
                        return -5;
                    }

                case "RI":
                    {
                        int ganho = 1;
                        if (codDino == "Ti") ganho += 1;
                        return ganho;
                    }

                default:
                    return 0;
            }
        }

        private (string dino, string cercado) MelhorJogadaGeral()
            => EscolherMelhorJogadaEntre(p.tabuleiro.Keys.ToList());

        private (string dino, string cercado) JogadaSegura()
        {
            if (jogador.dinossauros.Count == 0) return (null, null);
            string dino = EscolherDinoMenosValioso();
            return (dino, "RI");
        }

        private int ContarDinoNoZoo(string codDino)
            => p.tabuleiro.Values.Sum(lista => lista.Count(d => d == codDino));

        private string EscolherDinoMenosValioso()
        {
            if (jogador.dinossauros.Count == 0) return null;
            return jogador.dinossauros
                .GroupBy(d => d)
                .OrderBy(g => g.Count())
                .First().Key;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
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
            this.btnVerificarTurno = new System.Windows.Forms.Button();
            this.tmrVerificarPartida = new System.Windows.Forms.Timer(this.components);
            this.lblTestTimer = new System.Windows.Forms.Label();
            this.lblDinoEscolhido = new System.Windows.Forms.Label();
            this.lblCampoEscolhido = new System.Windows.Forms.Label();
            this.btnIniciarAgente = new System.Windows.Forms.Button();
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
            this.txtFaceDado.Size = new System.Drawing.Size(139, 22);
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
            this.btnVerificarPartida.Location = new System.Drawing.Point(509, 486);
            this.btnVerificarPartida.Name = "btnVerificarPartida";
            this.btnVerificarPartida.Size = new System.Drawing.Size(119, 23);
            this.btnVerificarPartida.TabIndex = 43;
            this.btnVerificarPartida.Text = "Verificar Partida";
            this.btnVerificarPartida.UseVisualStyleBackColor = true;
            this.btnVerificarPartida.Click += new System.EventHandler(this.btnVerificarPartida_Click);
            // 
            // btnVerificarTurno
            // 
            this.btnVerificarTurno.Location = new System.Drawing.Point(634, 486);
            this.btnVerificarTurno.Name = "btnVerificarTurno";
            this.btnVerificarTurno.Size = new System.Drawing.Size(119, 23);
            this.btnVerificarTurno.TabIndex = 44;
            this.btnVerificarTurno.Text = "Verificar Turno";
            this.btnVerificarTurno.UseVisualStyleBackColor = true;
            this.btnVerificarTurno.Click += new System.EventHandler(this.btnVerificarTurno_Click);
            // 
            // tmrVerificarPartida
            // 
            this.tmrVerificarPartida.Interval = 5000;
            this.tmrVerificarPartida.Tick += new System.EventHandler(this.tmrVerificarPartida_Tick);
            // 
            // lblTestTimer
            // 
            this.lblTestTimer.AutoSize = true;
            this.lblTestTimer.Location = new System.Drawing.Point(449, 554);
            this.lblTestTimer.Name = "lblTestTimer";
            this.lblTestTimer.Size = new System.Drawing.Size(54, 16);
            this.lblTestTimer.TabIndex = 45;
            this.lblTestTimer.Text = "Tempo:";
            // 
            // lblDinoEscolhido
            // 
            this.lblDinoEscolhido.AutoSize = true;
            this.lblDinoEscolhido.Location = new System.Drawing.Point(402, 586);
            this.lblDinoEscolhido.Name = "lblDinoEscolhido";
            this.lblDinoEscolhido.Size = new System.Drawing.Size(101, 16);
            this.lblDinoEscolhido.TabIndex = 46;
            this.lblDinoEscolhido.Text = "Dino Escolhido:";
            // 
            // lblCampoEscolhido
            // 
            this.lblCampoEscolhido.AutoSize = true;
            this.lblCampoEscolhido.Location = new System.Drawing.Point(386, 619);
            this.lblCampoEscolhido.Name = "lblCampoEscolhido";
            this.lblCampoEscolhido.Size = new System.Drawing.Size(117, 16);
            this.lblCampoEscolhido.TabIndex = 47;
            this.lblCampoEscolhido.Text = "Campo Escolhido:";
            // 
            // btnIniciarAgente
            // 
            this.btnIniciarAgente.Location = new System.Drawing.Point(283, 519);
            this.btnIniciarAgente.Name = "btnIniciarAgente";
            this.btnIniciarAgente.Size = new System.Drawing.Size(104, 26);
            this.btnIniciarAgente.TabIndex = 48;
            this.btnIniciarAgente.Text = "Iniciar Agente";
            this.btnIniciarAgente.UseVisualStyleBackColor = true;
            this.btnIniciarAgente.Click += new System.EventHandler(this.btnIniciarAgente_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(934, 660);
            this.Controls.Add(this.btnIniciarAgente);
            this.Controls.Add(this.lblCampoEscolhido);
            this.Controls.Add(this.lblDinoEscolhido);
            this.Controls.Add(this.lblTestTimer);
            this.Controls.Add(this.btnVerificarTurno);
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
    }
}