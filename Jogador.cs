using Draft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PI_3___2026
{
    internal class Jogador
    {
        public int id;
        public string name;
        public string senha;
        public List<string> dinossauros = new List<string>();

        public int Id { get; set; }
        public string Nome { get; set; }

        public int Pontuacao { get; set; }

        public override string ToString()
        {
            return $"{Id},{Nome}, {Pontuacao}";
        }

        public Jogador() { }

        public Jogador(int idJogador, string nome, string senha)
        {
            this.id = idJogador;
            this.name = nome;
            this.senha = senha;
        }

        public void Jogar(string codDino, string codCercado)
        {
            string retorno = Jogo.Jogar(this.id, this.senha, codDino, codCercado);
        }
    }
}
