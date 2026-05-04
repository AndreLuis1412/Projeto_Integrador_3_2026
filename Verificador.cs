using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_3___2026
{
    internal class Verificador
    {
        public bool VerificarErro(string verificacao)
        {
            /*
             Função verifica se há algum tipo de erro, qualquer que ele seja
            - verificacao = string de retorno de alguma função da DLL
            - senhaPartida = Senha para a atribuir a partida
             Retorna um valor booleano e uma mensagem na tela no caso de true(verificou um erro)
             */
            if (verificacao != "")
            {
                if (verificacao.Substring(0, 2) == "ER")
                {
                    MessageBox.Show("Ocorreu um erro:\n" + verificacao.Substring(5), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            else if (verificacao == "")
            {
                MessageBox.Show("Não há o que exibir", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }
        public bool VerificarErroJogada(string campoJogada, string faceDado)
        {
            /*
             Função verifica se há algum tipo de erro em uma jogada, qualquer que ele seja
            - campoJogada = Campo no qual o player quis fazer uma jogada,
            - faceDado = Face do dado que caiu
             Retorna um valor booleano e uma mensagem na tela no caso de true(verificou um erro)
             */
            if (faceDado == "AL" && (campoJogada == "" ||))
                return false;
            else if (faceDado == "FL" && (campoJogada == "" ||))
                return false;
            else if (faceDado == "PR" && (campoJogada == "" ||))
                return false;
            else if (faceDado == "TI" && (campoJogada == "" ||))
                return false;
            else if ((faceDado == "VZ" && (campoJogada == "" ||))
                return false;
            else if ((faceDado == "WC" && (campoJogada == "" ||))
                return false;

            MessageBox.Show("Ocorreu um erro:\nJogada Inválida, jogue no campo correto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }
    }
}