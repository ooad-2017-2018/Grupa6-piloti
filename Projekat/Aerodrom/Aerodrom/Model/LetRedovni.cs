using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.Model
{
    public class LetRedovni : Let
    {
        Linija linija;

        public LetRedovni() { }
        public LetRedovni(Linija linija)
        {
            this.Linija = linija;
        }

        public Linija Linija { get => linija; set => linija = value; }
    }
}
