using Draft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_3___2026
{
    internal class Partida
    {

        public int Criar(string nomePartida, string senhaPartida, string nomeGrupo = "Fossilistas")
        {
            /*
             Função cria uma nova partida apartir dos parâmetros:
            - NomePartida = Nome da partida a ser criada,
            - senhaPartida = Senha para a atribuir a partida
            - nomeGrupo = Nome do grupo que está criando a partida
             Retorna um inteiro, correspondendo ao ID da partida criada
             */
            
            int retorno = Convert.ToInt32(Jogo.CriarPartida(nomePartida, senhaPartida, nomeGrupo));
            return retorno;
        }

        public string[] ListarPartidas(string status = "T")
        {
            /*
             Função lista todas partidas existentes, com o parametro Status, que pode ser:
            - T = Retorna todas as partidas existentes independente dos status
            - X = 
            - X = 
            - X = 
             Retorna um array contendo em cada um de suas linhas, uma partida
             */

            string retorno = Jogo.ListarPartidas(status);

            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);

            string []retornos = retorno.Split('\n');
            return retornos;
        }

        public string[] Inciar(int idJogador, string senhaJogador)
        {
            /*
             Função inicia uma nova partida apartir dos parâmetros:
            - idJogador = id do jogador que vai iniciar a partida,
            - senhaJogador = senha correspondente a um jogador na partida a ser iniciada
             Retorna um array contendo id do jogador que jogou o dado e a face do dado
             */
            string retorno = Jogo.Iniciar(idJogador, senhaJogador);
            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);

            string[] retornos = retorno.Split('\n');
            return retornos;
        }
    }
}
