namespace Aerodrom.Model
{
    public abstract class Zahtjev
    {
        static int globalID = 0;

        int id;
        bool obradjen;
        bool prihvacen;

        public Zahtjev() { }

        public Zahtjev(bool obradjen, bool prihvacen)
        {
            Id = globalID++;
            this.Obradjen = obradjen;
            this.Prihvacen = prihvacen;
        }

        public bool Obradjen { get => obradjen; set => obradjen = value; }
        public bool Prihvacen { get => prihvacen; set => prihvacen = value; }
        public int Id { get => id; set => id = value; }
    }
}
