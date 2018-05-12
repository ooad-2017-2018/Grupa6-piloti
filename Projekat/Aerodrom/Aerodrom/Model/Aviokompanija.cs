using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.Model
{
    public class Aviokompanija
    {
        static int globalID = 0;

        private int id;
        private string naziv;
        private string kontaktOsoba;
        private string telefon;
        private string email;


        public Aviokompanija() { }
        public Aviokompanija(string naziv, string kontaktOsoba, string telefon, string email)
        {
            this.Id = globalID++;
            this.Naziv = naziv;
            this.KontaktOsoba = kontaktOsoba;
            this.Telefon = telefon;
            this.Email = email;
        }

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string KontaktOsoba { get => kontaktOsoba; set => kontaktOsoba = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email { get => email; set => email = value; }
    }
}
