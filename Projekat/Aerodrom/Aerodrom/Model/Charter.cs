using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.Model
{
    public class Charter : Let
    {
        Avion avion;

        public Charter() { }
        public Charter(Avion avion)
        {
            this.Avion = avion;
        }

        public Avion Avion { get => avion; set => avion = value; }
    }
}
