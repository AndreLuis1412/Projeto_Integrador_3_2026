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
            if (string.IsNullOrEmpty(verificacao))
            {
                MessageBox.Show("Não há o que exibir", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            if (verificacao.Length >= 2 && verificacao.Substring(0, 2) == "ER")
            {
                string mensagem = verificacao.Length > 5
                    ? verificacao.Substring(5)
                    : verificacao;

                MessageBox.Show("Ocorreu um erro:\n" + mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        public bool VerificarErroSilencioso(string verificacao)
        {
            if (string.IsNullOrEmpty(verificacao))
                return true;

            if (verificacao.Length >= 2 && verificacao.Substring(0, 2) == "ER")
                return true;

            return false;
        }
    }
}