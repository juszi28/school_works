using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Csapat
    {
        public int Csapat_id { get; set; }
        public string Név { get; set; }
        public int Baj_id { get; set; }
        public string Edző_név { get; set; }
        public string Edző_nemzet { get; set; }
        public string Stadion { get; set; }

        public override string ToString()
        {
            return Név + "\tEdző: " + Edző_név;
        }

        public string Kiír()
        {
            return Név;
        }

    }
}
