namespace Aerodrom.Model
{
    public class Putnik : Osoba
    {
        private string brojDokumenta;
        private bool ukrcan;

        public Putnik() { }
        public Putnik(string brojDokumenta, bool ukrcan)
        {
            this.BrojDokumenta = brojDokumenta;
            this.Ukrcan = ukrcan;
        }

        public string BrojDokumenta { get => brojDokumenta; set => brojDokumenta = value; }
        public bool Ukrcan { get => ukrcan; set => ukrcan = value; }
    }
}
