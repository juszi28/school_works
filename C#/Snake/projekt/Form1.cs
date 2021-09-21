using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace projekt
{
    public partial class Form1 : Form
    {
        private List<Kör> Snake = new List<Kör>();
        private Kör alma = new Kör();
        int a;


        public Form1()
        {

            InitializeComponent();
            new beállítások();
            StreamReader f = new StreamReader("rekord.txt");
            a = Convert.ToInt32(f.ReadLine());
            f.Close();
            játékidő.Interval = 1000 / beállítások.sebesség;
            játékidő.Tick += friss;
            játékidő.Start();
            highscore.Text = Convert.ToString(a);
            Start();
        }

        private void Start()
        {
            végüzenet.Visible = false;
            new beállítások();
            
            Snake.Clear();
            Kör fej = new Kör { X = 10, Y = 5 };
            Snake.Add(fej);

            Pontszám.Text = beállítások.összpont.ToString();
            újalma();
        }

        private void újalma()
        {
            int maxX = main.Size.Width / beállítások.szélesség;
            int maxY = main.Size.Height / beállítások.magasság;

            Random vél = new Random();
            alma = new Kör();
            alma.X = vél.Next(0, maxX);
            alma.Y = vél.Next(0, maxY);
        }

        private void friss(object send, EventArgs e)
        {
            if (beállítások.GameOver)
            {
                if (Kimenet.KeyPressed(Keys.Enter))
                {
                    Start();
                }
            }

            else
            {
                if (Kimenet.KeyPressed(Keys.Right) && beállítások.irányok != irányok.balra)
                    beállítások.irányok = irányok.jobbra;
                else if (Kimenet.KeyPressed(Keys.Left) && beállítások.irányok != irányok.jobbra)
                    beállítások.irányok = irányok.balra;
                else if (Kimenet.KeyPressed(Keys.Up) && beállítások.irányok != irányok.le)
                    beállítások.irányok = irányok.fel;
                else if (Kimenet.KeyPressed(Keys.Down) && beállítások.irányok != irányok.fel)
                    beállítások.irányok = irányok.le;

                Mozgás();
            }

            main.Invalidate();
        }

        private void main_Paint(object sender, PaintEventArgs e)
        {
            Graphics main = e.Graphics;

            if (!beállítások.GameOver)
            {
                Brush snakeszín;
                for (int i = 0; i < Snake.Count; ++i)
                {

                    if (i == 0)
                        snakeszín = Brushes.Black;
                    else
                        snakeszín = Brushes.RoyalBlue;
                    main.FillEllipse(snakeszín, new Rectangle(Snake[i].X * beállítások.szélesség, Snake[i].Y * beállítások.magasság, beállítások.szélesség, beállítások.magasság));

                    main.FillEllipse(Brushes.Red, new Rectangle(alma.X * beállítások.szélesség, alma.Y * beállítások.magasság, beállítások.szélesség, beállítások.magasság));

                }
            }
            else
            {
                string játékv = "Vége a játéknak, a pontszámod: " + beállítások.összpont + " \nNyomj Entert új játékhoz";
                végüzenet.Text = játékv;
                végüzenet.Visible = true;
                if (beállítások.összpont > a)
                {
                    a = beállítások.összpont;
                    highscore.Text = Convert.ToString(a);
                    var f = new List<string>(System.IO.File.ReadAllLines("rekord.txt"));
                    f.RemoveAt(0);
                    File.WriteAllLines("rekord.txt", f.ToArray());
                    using (StreamWriter k = new StreamWriter("rekord.txt", true))
                    {
                        k.Write(Convert.ToString(a));
                    }
                }
            }
        }

        private void Mozgás()
        {
            for (int i = Snake.Count - 1; i >= 0; --i)
            {
                if (i == 0)
                {
                    switch (beállítások.irányok)
                    {
                        case irányok.jobbra:
                            Snake[i].X++;
                            break;
                        case irányok.balra:
                            Snake[i].X--;
                            break;
                        case irányok.fel:
                            Snake[i].Y--;
                            break;
                        case irányok.le:
                            Snake[i].Y++;
                            break;
                    }

                    int maxX = main.Size.Width / beállítások.szélesség;
                    int maxY = main.Size.Height / beállítások.magasság;

                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= maxX || Snake[i].Y >= maxY)
                    {
                        vége();
                    }

                    for (int j = 1; j < Snake.Count; ++j)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            vége();
                        }
                    }

                    if (Snake[0].X == alma.X && Snake[0].Y == alma.Y)
                    {
                        fel();
                    }

                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void fel()
        {
            Kör alma = new Kör();
            alma.X = Snake[Snake.Count - 1].X;
            alma.Y = Snake[Snake.Count - 1].Y;

            Snake.Add(alma);
            System.Media.SoundPlayer zene = new System.Media.SoundPlayer();
            zene.SoundLocation = "Ding Sound Effect.wav";
            zene.Play(); 
            beállítások.összpont += beállítások.pont;
            Pontszám.Text = beállítások.összpont.ToString();

            újalma();
        }

        private void vége()
        {
            beállítások.GameOver = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Kimenet.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Kimenet.ChangeState(e.KeyCode, false);
        }


    }
}