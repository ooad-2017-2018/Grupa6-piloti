using System;
using System.Collections.Generic;
using System.Text;

namespace Aerodrom.Model
{
    public enum Dan{Ponedeljak, Utorak, Srijeda, Cetvrtak, Petak, Subota, Nedelja};
    public class Linija
    {
        private static int IzborDaniDolazaka = 0;
        private static int IzborDaniOdlazaka = 1;
        private string id;
        private string brojLinije;
        private string destinacija;
        private string idAviokompanije;//mozemo kasnije da drzi aviokompaniju, pa preko setera staviti da se u tabeli drzi id
        private string idAviona;//-||-
        private double prosjecnoTrajanje;
        private double cijena;
        private List<Dan> daniDolazaka = new List<Dan>();
        private List<Dan> daniOdlazaka = new List<Dan>();
        private string daniDolazakaString;
        private string daniOdlazakaString;
        private string vrijemeDolazaka;//-||-
        private string vrijemeOdlazaka;//-||-
        private bool postojeca;

        public Linija() { }
        public Linija(string brojLinije, string destinacija, string idAviokompanije, string idAviona, double prosjecnoTrajanje, double cijena, List<Dan> daniDolazaka, List<Dan> daniOdlazaka, string vrijemeDolazaka, string vrijemeOdlazaka,bool postojeca)
        {
            this.BrojLinije = brojLinije;
            this.Destinacija = destinacija;
            this.idAviokompanije = idAviokompanije;
            this.idAviona = idAviona;
            this.ProsjecnoTrajanje = prosjecnoTrajanje;
            this.Cijena = cijena;
            this.DaniDolazaka = daniDolazaka;
            this.DaniOdlazaka = daniOdlazaka;
            this.VrijemeDolazaka = vrijemeDolazaka;
            this.VrijemeOdlazaka = vrijemeOdlazaka;
            this.postojeca = postojeca;
        }

        public string BrojLinije { get => brojLinije; set => brojLinije = value; }
        public string Destinacija { get => destinacija; set => destinacija = value; }
        public string IdAviokompanije { get => idAviokompanije; set => idAviokompanije = value; }
        public string IdAviona { get => idAviona; set => idAviona = value; }
        public double ProsjecnoTrajanje { get => prosjecnoTrajanje; set => prosjecnoTrajanje = value; }
        public double Cijena { get => cijena; set => cijena = value; }
        public string VrijemeDolazaka { get => vrijemeDolazaka; set => vrijemeDolazaka = value; }
        public string VrijemeOdlazaka { get => vrijemeOdlazaka; set => vrijemeOdlazaka = value; }



        private void setListaDana(List<Dan> lista,int izbor)
        {
            if (izbor == IzborDaniDolazaka)
            {
                daniDolazaka = lista;
                if (daniDolazaka != null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (Dan x in daniDolazaka)
                    {
                        sb.Append(x.ToString());
                        sb.Append(',');
                    }
                    daniDolazakaString = sb.ToString().TrimEnd(',');
                }
                else daniDolazakaString = null;
            }
            else if (izbor == IzborDaniOdlazaka)
            {
                daniOdlazaka = lista;
                if (daniOdlazaka != null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (Dan x in daniOdlazaka)
                    {
                        sb.Append(x.ToString());
                        sb.Append(',');
                    }
                    daniOdlazakaString = sb.ToString().TrimEnd(',');
                }
                else daniOdlazakaString = null;
            }
        }
        private void setStringDana(string dani,int izbor)
        {
            if (izbor == IzborDaniDolazaka)
            {
                daniDolazakaString = dani;
                if (!String.IsNullOrEmpty(daniDolazakaString))
                {
                    daniDolazaka = new List<Dan>();
                    string[] niz = daniDolazakaString.Split(',');
                    for (int i = 0; i < niz.Length; i++)
                    {
                        Dan dan;
                        bool uspio = Enum.TryParse(niz[i], out dan);
                        if (uspio) daniDolazaka.Add(dan);
                    }
                }
                else if (daniDolazakaString == String.Empty) daniDolazaka = new List<Dan>();
                else daniDolazaka = null;
            }
            else if (izbor == IzborDaniOdlazaka)
            {
                daniOdlazakaString = dani;
                if (!String.IsNullOrEmpty(daniOdlazakaString))
                {
                    daniOdlazaka = new List<Dan>();
                    string[] niz = daniOdlazakaString.Split(',');
                    for (int i = 0; i < niz.Length; i++)
                    {
                        Dan dan;
                        bool uspio = Enum.TryParse(niz[i], out dan);
                        if (uspio) daniOdlazaka.Add(dan);
                    }
                }
                else if (daniOdlazakaString == String.Empty) daniOdlazaka = new List<Dan>();
                else daniOdlazaka = null;
            }
        }
        //aplikacija pristupa preko ovoga
        public List<Dan> DaniDolazaka { 
            set
            {
                setListaDana(value, IzborDaniDolazaka);
            }
        }
        //umjesto getera(obrisali zbog tabela) za liste ispod napravit f-je da pristupa
        public List<Dan> DaniOdlazaka
        {
            set
            {
                setListaDana(value, IzborDaniOdlazaka);
            }
        }
        //tabela pristupa preko ovoga
        public string DaniDolazakaString { get => daniDolazakaString;
            set {
                setStringDana(value, IzborDaniDolazaka);
            }
        }
        public string DaniOdlazakaString
        {
            get => daniOdlazakaString;
            set
            {
                setStringDana(value, IzborDaniOdlazaka);
            }
        }

        public bool Postojeca { get => postojeca; set => postojeca = value; }
        public string Id { get => id; set => id = value; }
    }
}
