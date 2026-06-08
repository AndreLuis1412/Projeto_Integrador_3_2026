using Draft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_3___2026
{
    internal class Partida
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Id { get; set; }
        public char Status { get; set; }
        public string DataCriacao { get; set; }

        public List<Jogador> jogadores { get; set; }

        public Dictionary<string, List<string>> tabuleiro = new Dictionary<string, List<string>>();

        private static Verificador verificador = new Verificador();

        private Jogador jogador;

        public override string ToString()
        {
            return $"{Id},{Nome},{DataCriacao},{Status}";
        }

        public Partida()
        {
            InicializarTabuleiro();
        }

        public Partida(int id)
        {
            this.Id = id;
            InicializarTabuleiro();
        }

        public Partida(int id, string senha)
        {
            this.Id = id;
            this.Senha = senha;
            InicializarTabuleiro();
        }

        private void InicializarTabuleiro()
        {
            tabuleiro = new Dictionary<string, List<string>>
            {
                { "CD", new List<string>() },
                { "FI", new List<string>() },
                { "IS", new List<string>() },
                { "MT", new List<string>() },
                { "PA", new List<string>() },
                { "RI", new List<string>() },
                { "RS", new List<string>() }
            };
        }

        public static List<Partida> ListarPartidas(string status = "T")
        {
            List<Partida> partidasObj = new List<Partida>();

            string retorno = Jogo.ListarPartidas(status);

            if (verificador.VerificarErro(retorno))
                return partidasObj;

            try
            {
                retorno = retorno.Replace("\r", "").TrimEnd('\n');

                string[] partidas = retorno.Split('\n');

                foreach (string linha in partidas)
                {
                    if (string.IsNullOrWhiteSpace(linha)) continue;

                    string[] dados = linha.Split(',');
                    if (dados.Length < 4) continue;

                    Partida p = new Partida
                    {
                        Id = Convert.ToInt32(dados[0]),
                        Nome = dados[1],
                        DataCriacao = dados[2],
                        Status = Convert.ToChar(dados[3])
                    };

                    partidasObj.Add(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar partidas:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return partidasObj;
        }

        public List<Jogador> ListarJogadores()
        {
            jogadores = new List<Jogador>();
            string retornoJogadores = Jogo.ListarJogadores(this.Id);

            if (verificador.VerificarErro(retornoJogadores))
                return jogadores;

            try
            {
                retornoJogadores = retornoJogadores.Replace("\r", "").TrimEnd('\n');

                string[] jogadoresStr = retornoJogadores.Split('\n');

                foreach (string linha in jogadoresStr)
                {
                    if (string.IsNullOrWhiteSpace(linha)) continue;

                    string[] dados = linha.Split(',');
                    if (dados.Length < 3) continue;

                    Jogador j = new Jogador
                    {
                        Id = Convert.ToInt32(dados[0]),
                        Nome = dados[1],
                        Pontuacao = Convert.ToInt32(dados[2])
                    };

                    jogadores.Add(j);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar jogadores:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return jogadores;
        }

        public static Partida CriarPartida(string nomePartida, string senhaPartida)
        {
            string retorno = Jogo.CriarPartida(nomePartida, senhaPartida, "Fossilistas");

            if (verificador.VerificarErro(retorno))
                return null;

            try
            {
                Partida p = new Partida
                {
                    Id = Convert.ToInt32(retorno.Trim()),
                    Nome = nomePartida,
                    Senha = senhaPartida
                };
                return p;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar partida:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public string[] VerificarPartida()
        {
            string retorno = Jogo.VerificarPartida(this.Id);

            if (verificador.VerificarErro(retorno))
                return null;

            try
            {
                retorno = retorno.Replace("\r", "").TrimEnd('\n');
                return retorno.Split(',');
            }
            catch
            {
                return null;
            }
        }

        public Jogador EntrarPartida(int idPartida, string nomeJogador, string senhaPartida)
        {
            string retorno = Jogo.Entrar(idPartida, nomeJogador, senhaPartida);

            if (verificador.VerificarErro(retorno))
                return null;

            try
            {
                retorno = retorno.Replace("\r", "");
                string[] dados = retorno.Split(',');

                jogador = new Jogador(Convert.ToInt32(dados[0]), nomeJogador, dados[1]);
                return jogador;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao entrar na partida:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}