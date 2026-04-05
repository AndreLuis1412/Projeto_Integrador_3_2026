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
        public DateTime DataCriacao { get; set; }

        public List<Jogador> jogadores { get; set; }
        public override string ToString()
        {
            return $"{Id},{Nome},{DataCriacao},{Status}";
        }

        public static List<Partida> ListarPartidas()
        {
            List<Partida> partidasObj = new List<Partida>();

            string retorno = Jogo.ListarPartidas("T");
            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);

            string[] partidas = retorno.Split('\n');

            for (int i = 0; i < partidas.Length; i++)
            {
                Partida p = new Partida();
                string[] dados = partidas[i].Split(',');

                p.Id = Convert.ToInt32(dados[0]);
                p.Nome = dados[1];
                p.DataCriacao = Convert.ToDateTime(dados[2]);
                p.Status = Convert.ToChar(dados[3]);

                partidasObj.Add(p);
            }

            return partidasObj;
        }

        public List<Jogador> ListarJogadores()
        {
            jogadores = new List<Jogador>(); 
            string retornoJogadores = Jogo.ListarJogadores(this.Id);

            if (retornoJogadores.Substring(0, 4) == "ERRO" || retornoJogadores == "")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retornoJogadores.Substring(5), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
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
            if (retornoCriarPartida.Substring(0, 2) == "ER")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retornoCriarPartida.Substring(5), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Partida p = new Partida();
                p.Nome = nomePartida;
                p.Senha = senhaPartida;

                return p;
            }
            return null;
        }
    }
}
