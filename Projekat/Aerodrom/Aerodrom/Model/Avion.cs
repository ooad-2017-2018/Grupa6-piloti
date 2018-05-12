using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.Model
{
    public class Avion
    {
        private string naziv;
        private int brojMjesta;
        private double dozvoljenaPrtljagaPoOsobi;
        private double potrebnaDuzinaPiste;

        public Avion(string naziv, int brojMjesta, double dozvoljenaPrtljagaPoOsobi, double potrebnaDuzinaPiste)
        {
            this.Naziv = naziv;
            this.BrojMjesta = brojMjesta;
            this.DozvoljenaPrtljagaPoOsobi = dozvoljenaPrtljagaPoOsobi;
            this.PotrebnaDuzinaPiste = potrebnaDuzinaPiste;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public int BrojMjesta { get => brojMjesta; set => brojMjesta = value; }
        public double DozvoljenaPrtljagaPoOsobi { get => dozvoljenaPrtljagaPoOsobi; set => dozvoljenaPrtljagaPoOsobi = value; }
        public double PotrebnaDuzinaPiste { get => potrebnaDuzinaPiste; set => potrebnaDuzinaPiste = value; }
    }
}
