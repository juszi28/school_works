using System;
using System.Collections.Generic;
using System.Text;

namespace Awari.Model
{
    public class AwariEventArgs
    {
        private int redPot;
        private int bluePot;

        public int RedPot { get { return redPot; } }
        public int BluePot { get { return bluePot; } }

        public AwariEventArgs(int blue, int red)
        {
            redPot = red;
            bluePot = blue;
        }
    }
}
