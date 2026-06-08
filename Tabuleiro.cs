using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PI_3___2026
{
    public partial class Tabuleiro : Form
    {
        // ─── Caminho base das imagens ─────────────────────────────────────────
        private readonly string _imagensPath = @"C:\Users\oandr\BCC\PI 3 - 2026\Projeto_Integrador_3_2026\Images";

        // ─── Tamanho dos dinos (ajuste conforme necessário) ───────────────────
        private const int DINO_W = 40;
        private const int DINO_H = 83;

        // ─── Mapa código DLL → nome do arquivo de imagem ─────────────────────
        private readonly Dictionary<string, string> _nomeImagem = new Dictionary<string, string>
        {
            { "Br", "Braquiossauro.png"  },
            { "Ep", "Espinossauro.png"   },
            { "Et", "Estegossauro.png"   },
            { "Pa", "Parasaurolofo.png"  },
            { "Ti", "Tiranossauro.png"   },
            { "Tr", "Triceratops.png"    }
        };

        private readonly Dictionary<string, Point> _posicaoCercado = new Dictionary<string, Point>
        {
            { "FI", new Point(30,  80)   },
            { "CD", new Point(520, 505)  },
            { "PA", new Point(75,  775)  },
            { "MT", new Point(50, 480)   },
            { "RS", new Point(500, 70)   },
            { "IS", new Point(410, 710)  },
            { "RI", new Point(390,  800) },
        };

        // ─── Quantos dinos por linha em cada cercado ──────────────────────────
        private readonly Dictionary<string, int> _colunasCercado = new Dictionary<string, int>
        {
            { "FI", 6 },
            { "CD", 6 },
            { "PA", 4 },
            { "MT", 3 },
            { "RS", 1 },
            { "IS", 1 },
            { "RI", 7 },
        };

        private Dictionary<string, Image> _imgCache = new Dictionary<string, Image>();

        private Dictionary<string, List<string>> _tabuleiro;

        private Panel _painelDinos;

        public Tabuleiro()
        {
            InitializeComponent(); 
            ConfigurarPainelDinos();
            CarregarImagemFundo();
        }

        private void ConfigurarPainelDinos()
        {
            _painelDinos = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(866, 862),
                BackColor = Color.Transparent,
            };
            _painelDinos.Paint += PainelDinos_Paint;

            // Painel por cima de tudo
            this.Controls.Add(_painelDinos);
            _painelDinos.BringToFront();
        }

        private void CarregarImagemFundo()
        {
            string caminhoTabuleiro = Path.Combine(_imagensPath, "Tabuleiro.jpg");

            if (!File.Exists(caminhoTabuleiro))
            {
                MessageBox.Show("Imagem não encontrada:\n" + caminhoTabuleiro);
                return;
            }

            this.BackgroundImage = Image.FromFile(caminhoTabuleiro);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void AtualizarTabuleiro(Dictionary<string, List<string>> tabuleiro)
        {
            _tabuleiro = tabuleiro;
            _painelDinos.Invalidate();
        }

        // ─── Pintura dos dinossauros ──────────────────────────────────────────

        private void PainelDinos_Paint(object sender, PaintEventArgs e)
        {
            if (_tabuleiro == null) return;

            Graphics g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            foreach (var kvp in _tabuleiro)
            {
                string cercadoCod = kvp.Key;
                List<string> dinos = kvp.Value;

                if (!_posicaoCercado.ContainsKey(cercadoCod)) continue;

                Point origem = _posicaoCercado[cercadoCod];
                int colunas = _colunasCercado.ContainsKey(cercadoCod) ? _colunasCercado[cercadoCod] : 3;

                for (int i = 0; i < dinos.Count; i++)
                {
                    Image img = CarregarImagem(dinos[i]);
                    if (img == null) continue;

                    int col = i % colunas;
                    int lin = i / colunas;
                    int x = origem.X + col * (DINO_W + 4);
                    int y = origem.Y + lin * (DINO_H + 4);

                    g.DrawImage(img, new Rectangle(x, y, DINO_W, DINO_H));
                }
            }
        }

        // ─── Carregamento e transparência das imagens ─────────────────────────

        private Image CarregarImagem(string codDino)
        {
            if (_imgCache.ContainsKey(codDino))
                return _imgCache[codDino];

            if (!_nomeImagem.ContainsKey(codDino)) return null;

            string caminho = Path.Combine(_imagensPath, _nomeImagem[codDino]);
            if (!File.Exists(caminho)) return null;

            Bitmap bmp = new Bitmap(caminho);
            bmp = TornarFundoTransparente(bmp);
            _imgCache[codDino] = bmp;
            return bmp;
        }

        private Bitmap TornarFundoTransparente(Bitmap src)
        {
            Bitmap dest = new Bitmap(src.Width, src.Height, PixelFormat.Format32bppArgb);
            Color corFundo = src.GetPixel(0, 0);
            const int tolerancia = 30;

            for (int x = 0; x < src.Width; x++)
            {
                for (int y = 0; y < src.Height; y++)
                {
                    Color c = src.GetPixel(x, y);

                    bool eFundo = Math.Abs(c.R - corFundo.R) < tolerancia &&
                                  Math.Abs(c.G - corFundo.G) < tolerancia &&
                                  Math.Abs(c.B - corFundo.B) < tolerancia;

                    dest.SetPixel(x, y, eFundo ? Color.Transparent : c);
                }
            }

            return dest;
        }
    }
}