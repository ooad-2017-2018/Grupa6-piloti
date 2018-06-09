using System;

namespace Aerodrom.Model
{
    public enum Status { Odletio, Sletio, Ukrcavanje, CheckIn, Odgodjen};
    public abstract class Let
    {
        static int globalID = 0;

        int id;
        DateTime datumiVrijeme;
        Status status;

        public Let() { }

        public Let(DateTime datumiVrijeme, Status status)
        {
            this.Id = globalID++;
            this.DatumiVrijeme = datumiVrijeme;
            this.Status = status;
        }

        public int Id { get => id; set => id = value; }
        public DateTime DatumiVrijeme { get => datumiVrijeme; set => datumiVrijeme = value; }
        public Status Status { get => status; set => status = value; }
    }
}
