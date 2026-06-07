using Draft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_3___2026
{
    internal class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Pontuacao { get; set; }

        public List<string> dinossauros = new List<string>();

        public override string ToString()
        {
            return $"{Id},{Nome},{Pontuacao}";
        }

        public Jogador() { }

        public Jogador(int id, string nome, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Senha = senha;
        }

        public bool Jogar(string codDino, string codCercado)
        {
            string retorno = Jogo.Jogar(this.Id, this.Senha, codDino, codCercado);

            if (string.IsNullOrEmpty(retorno) || retorno.Length < 2)
                return false;

            if (retorno.Substring(0, 2) == "ER")
                return false;

            return true;
        }
    }
}