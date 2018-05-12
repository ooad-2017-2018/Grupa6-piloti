using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.Model
{
    public enum Dan{Ponedeljak, Utorak, Srijeda, Cetvrtak, Petak, Subota, Nedelja};
    public class Linija
    {
        private string brojLinije;
        private string destinacija;
        private Aviokompanija aviokompanija;
        private Avion avion;
        private double prosjecnoTrajanje;
        private double cijena;
        private List<Dan> daniDolazaka = new List<Dan>();
        private List<Dan> daniOdlazaka = new List<Dan>();
        private DateTime vrijemeDolazaka;
        private DateTime vrijemeOdlazaka;

        public Linija() { }
        public Linija(string brojLinije, string destinacija, Aviokompanija aviokompanija, Avion avion, double prosjecnoTrajanje, double cijena, List<Dan> daniDolazaka, List<Dan> daniOdlazaka, DateTime vrijemeDolazaka, DateTime vrijemeOdlazaka)
        {
            this.BrojLinije = brojLinije;
            this.Destinacija = destinacija;
            this.Aviokompanija = aviokompanija;
            this.Avion = avion;
            this.ProsjecnoTrajanje = prosjecnoTrajanje;
            this.Cijena = cijena;
            this.DaniDolazaka = daniDolazaka;
            this.DaniOdlazaka = daniOdlazaka;
            this.VrijemeDolazaka = vrijemeDolazaka;
            this.VrijemeOdlazaka = vrijemeOdlazaka;
        }

        public string BrojLinije { get => brojLinije; set => brojLinije = value; }
        public string Destinacija { get => destinacija; set => destinacija = value; }
        public Aviokompanija Aviokompanija { get => aviokompanija; set => aviokompanija = value; }
        public Avion Avion { get => avion; set => avion = value; }
        public double ProsjecnoTrajanje { get => prosjecnoTrajanje; set => prosjecnoTrajanje = value; }
        public double Cijena { get => cijena; set => cijena = value; }
        public List<Dan> DaniDolazaka { get => daniDolazaka; set => daniDolazaka = value; }
        public List<Dan> DaniOdlazaka { get => daniOdlazaka; set => daniOdlazaka = value; }
        public DateTime VrijemeDolazaka { get => vrijemeDolazaka; set => vrijemeDolazaka = value; }
        public DateTime VrijemeOdlazaka { get => vrijemeOdlazaka; set => vrijemeOdlazaka = value; }
    }
}
