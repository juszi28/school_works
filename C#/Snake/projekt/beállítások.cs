using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public enum irányok
    { 
        fel,
        le,
        jobbra,
        balra
    };


    class beállítások
    {
        public static int szélesség { get; set; }
        public static int magasság { get; set; }
        public static int sebesség { get; set; }
        public static int összpont { get; set; }
        public static int pont { get; set; }
        public static bool GameOver { get; set; }
        public static irányok irányok { get; set; }

        public beállítások()
        {
            szélesség = 16;
            magasság = 16;
            sebesség = 16;
            összpont = 0;
            pont = 1;
            GameOver = false;
            irányok = irányok.le;

        }
    }
}
