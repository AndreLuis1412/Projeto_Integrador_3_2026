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

        static Verificador verificador;

        Jogador jogador;


        public override string ToString()
        {
            return $"{Id},{Nome},{DataCriacao},{Status}";
        }

        public Partida() 
        {
            this.tabuleiro.Add("CD", new List<string>());
            this.tabuleiro.Add("FI", new List<string>());
            this.tabuleiro.Add("IS", new List<string>());
            this.tabuleiro.Add("MT", new List<string>());
            this.tabuleiro.Add("PA", new List<string>());
            this.tabuleiro.Add("RI", new List<string>());
            this.tabuleiro.Add("RS", new List<string>());
        }

        public Partida(int id)
        {
            this.Id = id ;
            this.tabuleiro.Add("CD", new List<string>());
            this.tabuleiro.Add("FI", new List<string>());
            this.tabuleiro.Add("IS", new List<string>());
            this.tabuleiro.Add("MT", new List<string>());
            this.tabuleiro.Add("PA", new List<string>());
            this.tabuleiro.Add("RI", new List<string>());
            this.tabuleiro.Add("RS", new List<string>());
        }

        public Partida(int id, string senha)
        {
            this.Id = id;
            this.Senha = senha;
            this.tabuleiro.Add("CD", new List<string>());
            this.tabuleiro.Add("FI", new List<string>());
            this.tabuleiro.Add("IS", new List<string>());
            this.tabuleiro.Add("MT", new List<string>());
            this.tabuleiro.Add("PA", new List<string>());
            this.tabuleiro.Add("RI", new List<string>());
            this.tabuleiro.Add("RS", new List<string>());
        }

        public static List<Partida> ListarPartidas(string status="T")
        {
            List<Partida> partidasObj = new List<Partida>();

            string retorno = Jogo.ListarPartidas(status);
            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);

            string[] partidas = retorno.Split('\n');

            for (int i = 0; i < partidas.Length; i++)
            {
                Partida p = new Partida();
                string[] dados = partidas[i].Split(',');

                p.Id = Convert.ToInt32(dados[0]);
                p.Nome = dados[1];
                p.DataCriacao = (dados[2]);
                p.Status = Convert.ToChar(dados[3]);

                partidasObj.Add(p);
            }

            return partidasObj;
        }

        public List<Jogador> ListarJogadores()
        {
            jogadores = new List<Jogador>();
            verificador = new Verificador();
            string retornoJogadores = Jogo.ListarJogadores(this.Id);
            bool erro = verificador.VerificarErro(retornoJogadores);

            if (!erro)
            {
                retornoJogadores = retornoJogadores.Replace("\r", "");
                retornoJogadores = retornoJogadores.Substring(0, retornoJogadores.Length - 1);

                string[] jogadoresStr = retornoJogadores.Split('\n');


                for (int i = 0; i < jogadoresStr.Length; i++)
                {
                    Jogador j = new Jogador();
                    string[] dados = jogadoresStr[i].Split(',');

                    j.Id = Convert.ToInt32(dados[0]);
                    j.Nome = dados[1];
                    j.Pontuacao = Convert.ToInt32(dados[2]);
                    jogadores.Add(j);
                }
            }
            return jogadores;
        }

        public static Partida CriarPartida(string nomePartida, string senhaPartida)
        {
            string retornoCriarPartida = Jogo.CriarPartida(nomePartida, senhaPartida, "Fossilistas");
            verificador = new Verificador();
            bool erro = verificador.VerificarErro(retornoCriarPartida);

            if (!erro)
            {

                Partida p = new Partida();
                p.Id = Convert.ToInt32(retornoCriarPartida);
                p.Nome = nomePartida;
                p.Senha = senhaPartida;

                return p;
            }
            return null;
        }

        public string[] VerificarPartida()
        {
            int idPartida = Convert.ToInt32(this.Id);
            string retorno = Jogo.VerificarPartida(idPartida);
            verificador = new Verificador();

            if (!verificador.VerificarErro(retorno))
            {
                retorno = retorno.Replace("\r", "");
                retorno = retorno.Substring(0, retorno.Length - 1);

                string[] listReturn = retorno.Split(',');
                return listReturn;
            }
            return null;
        }
        
        public Jogador EntrarPartida(int idPartida, string nomeJogador, string senhaPartida)
        {
            verificador = new Verificador();
            int idPartidaEntrar = Convert.ToInt32(idPartida);

            string retorno = Jogo.Entrar(idPartidaEntrar, nomeJogador, senhaPartida);
            bool erro = verificador.VerificarErro(retorno);
            if (!erro)
            {
                retorno = retorno.Replace("\r", "");
                string[] jogado = retorno.Split(',');

                int idJogador = Convert.ToInt32(jogado[0]);

                jogador = new Jogador(idJogador, nomeJogador, jogado[1]);

                return jogador;

            }

            return null;
        }
        

    }
}
