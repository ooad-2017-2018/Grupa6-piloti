using System.Collections.Generic;

namespace Aerodrom.Model
{
    public class Pista
    {
        static int globalID = 0;

        private int id;
        private double duzina;
        private bool zauzeta;
        private List<Avion> avioniKojePodrzava = new List<Avion>();

        public Pista() { }
        public Pista(double duzina, bool zauzeta, List<Avion> avioniKojePodrzava)
        {
            this.Id = globalID++;
            this.Duzina = duzina;
            this.Zauzeta = zauzeta;
            this.AvioniKojePodrzava = avioniKojePodrzava;
        }

        public int Id { get => id; set => id = value; }
        public double Duzina { get => duzina; set => duzina = value; }
        public bool Zauzeta { get => zauzeta; set => zauzeta = value; }
        public List<Avion> AvioniKojePodrzava { get => avioniKojePodrzava; set => avioniKojePodrzava = value; }
    }
}
