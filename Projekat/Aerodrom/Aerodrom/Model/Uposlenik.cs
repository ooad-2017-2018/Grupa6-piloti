namespace Aerodrom.Model
{
    public enum Pozicija { Uprava, SalterRezervacija, SalterCheckIn, Kontrolor}
    public class Uposlenik : Osoba
    {

        private string id;
        private double plata;
        private Pozicija pozicija;
        private string korisnickoIme;
        private string password;

        public Uposlenik() { }
        public Uposlenik(string ime, string prezime, string datumRodjenja, string telefon, string email,double plata,
            Pozicija pozicija, string korisnickoIme, string password):base(ime, prezime, datumRodjenja, telefon, email)
        {
            this.Plata = plata;
            this.Pozicija = pozicija;
            this.KorisnickoIme = korisnickoIme;
            this.Password = password;
        }
        public Uposlenik(string ime, string prezime, string datumRodjenja, string telefon, string email, double plata,
            Pozicija pozicija) : base(ime, prezime, datumRodjenja, telefon, email)
        {
            this.Plata = plata;
            this.Pozicija = pozicija;
        }

        public string Id { get => id; set => id = value; }
        public double Plata { get => plata; set => plata = value; }
        public Pozicija Pozicija { get => pozicija; set => pozicija = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Password { get => password; set => password = value; }
    }
}
