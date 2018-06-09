using System.Collections.Generic;

namespace Aerodrom.Model
{
    public enum Nacin { Online, NaSalteru};
    public class Rezervacija
    {
        static int globalID = 0;

        int id;
        Nacin nacinRezervacije;
        List<Karta> karte = new List<Karta>();
        double ukupnaCijenaRezervacije;

        public Rezervacija() { }
        public Rezervacija(Nacin nacinRezervacije, List<Karta> karte, double ukupnaCijenaRezervacije)
        {
            this.Id = globalID++;
            this.NacinRezervacije = nacinRezervacije;
            this.Karte = karte;
            this.UkupnaCijenaRezervacije = ukupnaCijenaRezervacije;
        }

        public int Id { get => id; set => id = value; }
        public Nacin NacinRezervacije { get => nacinRezervacije; set => nacinRezervacije = value; }
        public List<Karta> Karte { get => karte; set => karte = value; }
        public double UkupnaCijenaRezervacije { get => ukupnaCijenaRezervacije; set => ukupnaCijenaRezervacije = value; }
    }
}
