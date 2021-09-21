using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt
{
    class Kimenet
    {
        public static Hashtable billentyűzet = new Hashtable();
        
        public static bool KeyPressed(Keys key)
        {
            if(billentyűzet[key] == null)
            {
                return false;
            }
            return (bool) billentyűzet[key];
        }

        public static void ChangeState(Keys key, bool állapot)
        {
            billentyűzet[key] = állapot;
        }
    }

}
