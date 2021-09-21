using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Poszt
    {
        public int Poszt_id { get; set; }
        public string Név { get; set; }

        public override string ToString()
        {
            return Név;
        }
    }
}
