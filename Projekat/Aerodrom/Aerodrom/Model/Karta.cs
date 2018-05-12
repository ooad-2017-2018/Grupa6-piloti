using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.Model
{
    public class Karta
    {
        static int globalID = 0;

        //fale QR kodovi za skeniranje, ne znam koji tip atributa da stavim 
        int id;
        Let polazak;
        Let dolazak;
        double ukupnaCijena;
        Putnik putnik;

        public Karta(Let polazak, Let dolazak, double ukupnaCijena, Putnik putnik)
        {
            this.Id = globalID++;
            this.Polazak = polazak;
            this.Dolazak = dolazak;
            this.UkupnaCijena = ukupnaCijena;
            this.Putnik = putnik;
        }

        public int Id { get => id; set => id = value; }
        public Let Polazak { get => polazak; set => polazak = value; }
        public Let Dolazak { get => dolazak; set => dolazak = value; }
        public double UkupnaCijena { get => ukupnaCijena; set => ukupnaCijena = value; }
        public Putnik Putnik { get => putnik; set => putnik = value; }
    }
}
