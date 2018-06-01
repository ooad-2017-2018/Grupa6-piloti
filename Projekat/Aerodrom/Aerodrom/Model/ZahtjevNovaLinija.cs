using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.Model
{
    public class ZahtjevNovaLinija : Zahtjev
    {
        Linija linija;
        

        public ZahtjevNovaLinija() { }
        public ZahtjevNovaLinija(Linija linija)
        {
            this.Linija = linija;
            
        }

        public Linija Linija { get => linija; set => linija = value; }
    }
}
