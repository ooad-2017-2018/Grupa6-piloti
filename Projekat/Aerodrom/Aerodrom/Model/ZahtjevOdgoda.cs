namespace Aerodrom.Model
{
    public class ZahtjevOdgoda : Zahtjev
    {
        Let let;
        string razlogZaOdgodu;

        public ZahtjevOdgoda() { }
        public ZahtjevOdgoda(Let let, string razlogZaOdgodu)
        {
            this.Let = let;
            this.RazlogZaOdgodu = razlogZaOdgodu;
        }

        public Let Let { get => let; set => let = value; }
        public string RazlogZaOdgodu { get => razlogZaOdgodu; set => razlogZaOdgodu = value; }
    }
}
