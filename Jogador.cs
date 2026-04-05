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
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Pontuacao { get; set; }

        public override string ToString()
        {
            return $"{Id},{Nome}, {Pontuacao}";
        }
    }
}
