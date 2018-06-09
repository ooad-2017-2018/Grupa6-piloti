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
        bool prijavljen = false;

        public Karta(Let polazak, Let dolazak, double ukupnaCijena, Putnik putnik, bool prijavljen)
        {
            this.Id = globalID++;
            this.Polazak = polazak;
            this.Dolazak = dolazak;
            this.UkupnaCijena = ukupnaCijena;
            this.Putnik = putnik;
            this.Prijavljen = prijavljen;
        }

        public int Id { get => id; set => id = value; }
        public Let Polazak { get => polazak; set => polazak = value; }
        public Let Dolazak { get => dolazak; set => dolazak = value; }
        public double UkupnaCijena { get => ukupnaCijena; set => ukupnaCijena = value; }
        public Putnik Putnik { get => putnik; set => putnik = value; }
        public bool Prijavljen { get => prijavljen; set => prijavljen = value; }
    }
}
