namespace Aerodrom.Model
{
    
    public class Osoba
    {
        private string ime;
        private string prezime;
        private string datumRodjenja;
        private string telefon;
        private string email;


        public Osoba() { }
        public Osoba(string ime, string prezime, string datumRodjenja, string telefon, string email)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            
            this.telefon = telefon;
            this.email = email;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email { get => email; set => email = value; }
    }
}
