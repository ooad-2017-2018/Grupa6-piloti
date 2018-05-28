using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerodrom.Model;
using Aerodrom.ViewModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;using System.Data.SqlClient;

using Aerodrom.Helper;
using System.Runtime.CompilerServices;

namespace Aerodrom.ViewModel
{
    public class AdministratorViewModel : INotifyPropertyChanged
    {
        private ICommand izlaz;
        private INavigationService navigationService;

        //Pocetna

        string nazivAerodroma = Globalna.NazivAerodroma;
        string brojGateova = Globalna.BrojGateova.ToString();
        ObservableCollection<String> piste = Globalna.dohvatiPiste();
        ObservableCollection<String> avioni = Globalna.dohvatiAvione();
        ICommand spasiPromjene;

        //Upravljanje uposlenicima

        string ime;
        string prezime;
        DateTime datumRodjenja;
        string email;
        string telefon;
        ObservableCollection<string> pozicije = Globalna.dohvatiPozicije();
        string plata;
        string odabraniUposlenik = "Nesto";
        ICommand obrisiUposlenika;
        ICommand dodajIzmjeniUpslenika;
        ICommand ponistiUposlenika;




        public ICommand Izlaz { get => izlaz; set => izlaz = value; }
        internal INavigationService NavigationService { get => navigationService; set => navigationService = value; }
        public string NazivAerodroma { get => nazivAerodroma; set => nazivAerodroma = value; }
        public string BrojGateova { get => brojGateova; set => brojGateova = value; }
        public ObservableCollection<String> Piste { get => piste; set => piste = value; }
        public ObservableCollection<String> Avioni { get => avioni; set => avioni = value; }
        public ICommand SpasiPromjene { get => spasiPromjene; set => spasiPromjene = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Email { get => email; set => email = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public ObservableCollection<string> Pozicije { get => pozicije; set => pozicije = value; }
        public string Plata { get => plata; set => plata = value; }
        public ICommand ObrisiUposlenika { get => obrisiUposlenika; set => obrisiUposlenika = value; }
        public ICommand DodajIzmjeniUpslenika { get => dodajIzmjeniUpslenika; set => dodajIzmjeniUpslenika = value; }
        public ICommand PonistiUposlenika { get => ponistiUposlenika; set => ponistiUposlenika = value; }
        public string OdabraniUposlenik { get => odabraniUposlenik; set
            {
                odabraniUposlenik = value;
                OnNotifyPropertyChanged("OdabraniUposlenik");
            }
        }

        public AdministratorViewModel()
        {
            Izlaz = new RelayCommand<object>(Odjava, Provjera);
            SpasiPromjene = new RelayCommand<object>(IzmjenaInfo, ProvjeraInfo);
            ObrisiUposlenika = new RelayCommand<object>(BrisanjeUposlenika, Provjera);
            DodajIzmjeniUpslenika = new RelayCommand<object>(DodavanjeIzmjenaUposlenika, ProvjeraUposlenika);
            PonistiUposlenika = new RelayCommand<object>(PonistiPoljaUposlenika, Provjera);
            NavigationService = new NavigationService();

        }

        public void BrisanjeUposlenika(object Parametar)
        {
            //Implementirati brisanje odabranog uposlenika iz baze
        }

        public void DodavanjeIzmjenaUposlenika(object Parametar)
        {
           
            //Implementirati Dodavanje ili ako je odabran neki user njegovu izmjenu u bazi
        }

        public void PonistiPoljaUposlenika(object Parametar)
        {
           
            
            Ime = String.Empty;
            OnNotifyPropertyChanged("Ime");
            Prezime = String.Empty;
            OnNotifyPropertyChanged("Prezime");
            Email = String.Empty;
            OnNotifyPropertyChanged("Email");
            Telefon = String.Empty;
            OnNotifyPropertyChanged("Telefon");
            Plata = String.Empty;
            OnNotifyPropertyChanged("Plata");
        }

        public bool ProvjeraUposlenika(object Parametar)
        {
            
            if(Ime=="" || Prezime=="" || Email=="" || Telefon=="" || Plata=="")
            {
                var poruka = new MessageDialog("Neispravni podaci");
                poruka.ShowAsync();
                return false;
            }
            /*else if (!IsDigitsOnly(Plata) || !IsDigitsOnly(Telefon))
            {
                var poruka = new MessageDialog("Plata mora sadržavati isključivo brojeve");
                poruka.ShowAsync();
                return false;
            }
            else if(!containsAt(Email))
            {
                var poruka = new MessageDialog("Neispravan Email");
                poruka.ShowAsync();
                return false;
            }*/

            return true;
        }

        public bool ProvjeraInfo(object Parametar)
        {

            if (nazivAerodroma == String.Empty || NazivAerodroma == "" || BrojGateova == String.Empty || BrojGateova == "")
            {
                var poruka = new MessageDialog("Polja ne smiju biti prazna");
                poruka.ShowAsync();
                return false;
            }
            else if (!IsDigitsOnly(BrojGateova))
            {
                var poruka = new MessageDialog("Broj gate-ova mora sadržavati isključivo brojeve");
                poruka.ShowAsync();
                return false;
            }

            return true;
        }

        public void IzmjenaInfo(object Parametar)
        {
            //Promijeniti naziv i broj gateova

            Globalna.NazivAerodroma = NazivAerodroma;
            int x;
            int.TryParse(BrojGateova, out x);
            Globalna.BrojGateova = x;
     

        }


        public bool Provjera(object Parametar)
        {
            return true;
        }

        public void Odjava(object Parametar)
        {
            //Treba odjaviti user-a iz glavne
            NavigationService.Navigate(typeof(MainPage), new LoginViewModel(this));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }


       
        public static bool IsDigitsOnly(string str)
               {
                        foreach (char c in str)
                        {
                            if (c < '0' || c > '9')
                                return false;
                        }

                        return true;
               }

        public static bool containsAt(string s) {
           
            foreach(char c in s)
            {
                if (c.Equals( "@")) return true;
            }
            return false;
        }




    }

    
}
