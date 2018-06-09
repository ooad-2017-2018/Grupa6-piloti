namespace Aerodrom.Model
{
    public class Charter : Let
    {
        Avion avion;

        public Charter() { }
        public Charter(Avion avion)
        {
            this.Avion = avion;
        }

        public Avion Avion { get => avion; set => avion = value; }
    }
}
