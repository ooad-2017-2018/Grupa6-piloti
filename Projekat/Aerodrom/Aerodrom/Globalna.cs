using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Aerodrom.Model;

namespace Aerodrom
{
    public class Globalna
    {
        private static String nazivAerodroma = "Sarajevo International Airport";
        private static int brojGateova = 10;
        private static ObservableCollection<Avion> avioni = new ObservableCollection<Avion>();
        private static ObservableCollection<Pista> piste = new ObservableCollection<Pista>();
        

        public static string NazivAerodroma { get => nazivAerodroma; set => nazivAerodroma = value; }
        public static int BrojGateova { get => brojGateova; set => brojGateova = value; }
        public static ObservableCollection<Avion> Avioni { get => avioni; set => avioni = value; }
        public static ObservableCollection<Pista> Piste { get => piste; set => piste = value; }

       

        public Globalna()
        {
            ucitaj();
        }

        public void ucitaj()
        {
            Avioni.Add(new Avion("Boeing 737", 150, 25, 1500));
            Avioni.Add(new Avion("Boeing 777", 300, 22, 3500));
            Avioni.Add(new Avion("Boeing 787", 250, 25, 1300));
            Avioni.Add(new Avion("Airbus A380", 420, 23, 3000));

            List<Avion> a1 = new List<Avion>();
            a1.Add(Avioni[0]);
            a1.Add(Avioni[2]);

            List<Avion> a2 = new List<Avion>();
            a2.Add(Avioni[1]);
            a2.Add(Avioni[3]);

            Piste.Add(new Pista(2000, false, a1));
            Piste.Add(new Pista(4000, false, a2));

        }

        public static ObservableCollection<String> dohvatiAvione()
        {
            ObservableCollection<String> stringovi = new ObservableCollection<String>();
            for(int i=0; i<Avioni.Count; i++)
            {
                stringovi.Add(Avioni[i].Naziv);
            }

            return stringovi;
        }

        public static ObservableCollection<String> dohvatiPiste()
        {
            ObservableCollection<String> stringovi = new ObservableCollection<String>();
            for (int i = 0; i < Piste.Count; i++)
            {
                stringovi.Add(Piste[i].Id.ToString());
            }

            return stringovi;
        }

        public static ObservableCollection<String> dohvatiPozicije()
        {
            ObservableCollection<String> stringovi = new ObservableCollection<String>();
            stringovi.Add("Uprava");
            stringovi.Add("SalterRezervacija");
            stringovi.Add("SalterCheckIn");
            stringovi.Add("Kontrolor");

            return stringovi;

        }
    }

    


}
