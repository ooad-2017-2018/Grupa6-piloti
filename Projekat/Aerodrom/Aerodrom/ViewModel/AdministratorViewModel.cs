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

using Aerodrom.Helper;
using System.Runtime.CompilerServices;

namespace Aerodrom.ViewModel
{
    public class AdministratorViewModel : INotifyPropertyChanged
    {
        private ICommand izlaz;
        private INavigationService navigationService;

        //Pocetna

        String nazivAerodroma=Globalna.NazivAerodroma;
        String brojGateova = Globalna.BrojGateova.ToString() ;
        ObservableCollection<String> piste = Globalna.dohvatiPiste();
        ObservableCollection<String> avioni = Globalna.dohvatiAvione();
        ICommand spasiPromjene;


        public ICommand Izlaz { get => izlaz; set => izlaz = value; }
        internal INavigationService NavigationService { get => navigationService; set => navigationService = value; }
        public string NazivAerodroma { get => nazivAerodroma; set => nazivAerodroma = value; }
        public string BrojGateova { get => brojGateova; set => brojGateova = value; }
        public ObservableCollection<String> Piste { get => piste; set => piste = value; }
        public ObservableCollection<String> Avioni { get => avioni; set => avioni = value; }
        public ICommand SpasiPromjene { get => spasiPromjene; set => spasiPromjene = value; }

        public AdministratorViewModel()
        {
            Izlaz = new RelayCommand<object>(Odjava, Provjera);
            SpasiPromjene = new RelayCommand<object>(IzmjenaInfo, ProvjeraInfo);
            NavigationService = new NavigationService();

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


    }

    
}
