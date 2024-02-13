using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette_Forms
{
    class WheelField
    {
        public byte n;
        public Color c;

        public WheelField(byte n, Color c)
        {
            this.n = n;
            this.c = c;
        }
    }
}
