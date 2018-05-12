using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.Model
{
    public enum Pozicija { Uprava, SalterRezervacija, SalterCheckIn, Kontrolor}
    public abstract class Uposlenik : Osoba
    {
        static int globalID = 0;

        private int id;
        private double plata;
        private Pozicija pozicija;
        private string korisnickoIme;
        private string password;

        public Uposlenik() { }
        public Uposlenik(double plata, Pozicija pozicija, string korisnickoIme, string password)
        {
            this.Id = globalID++ ;
            this.Plata = plata;
            this.Pozicija = pozicija;
            this.KorisnickoIme = korisnickoIme;
            this.Password = password;
        }

        public int Id { get => id; set => id = value; }
        public double Plata { get => plata; set => plata = value; }
        public Pozicija Pozicija { get => pozicija; set => pozicija = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Password { get => password; set => password = value; }
    }
}
