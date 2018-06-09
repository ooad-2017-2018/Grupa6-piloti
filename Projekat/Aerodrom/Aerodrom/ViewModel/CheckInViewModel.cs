using System.Windows.Input;
using System.ComponentModel;
using Aerodrom.Helper;
using System.Runtime.CompilerServices;

namespace Aerodrom.ViewModel
{
    class CheckInViewModel : INotifyPropertyChanged
    {
        private INavigationService navigationService;
        string licniDokument;
        string tezinaPrtljaga;
        string prikazDoplate;
        string putnikInfo;
        ICommand izlaz;
        ICommand checkIn;
        ICommand provjeriPrtljag;
        ICommand pretrazi;

        public string LicniDokument { get => licniDokument; set => licniDokument = value; }
        public string TezinaPrtljaga { get => tezinaPrtljaga; set => tezinaPrtljaga = value; }
        public string PrikazDoplate { get => prikazDoplate; set => prikazDoplate = value; }
        public string PutnikInfo { get => putnikInfo; set => putnikInfo = value; }
        public ICommand Izlaz { get => izlaz; set => izlaz = value; }
        public ICommand CheckIn { get => checkIn; set => checkIn = value; }
        public ICommand ProvjeriPrtljag { get => provjeriPrtljag; set => provjeriPrtljag = value; }
        internal INavigationService NavigationService { get => navigationService; set => navigationService = value; }
        public ICommand Pretrazi { get => pretrazi; set => pretrazi = value; }

        public CheckInViewModel()
        {
            NavigationService = new NavigationService();
            Izlaz = new RelayCommand<object>(Odjava, Provjera);

            Pretrazi = new RelayCommand<object>(TraziKartu, Provjera);
            CheckIn = new RelayCommand<object>(PrijaviNaLet, Provjera);
            ProvjeriPrtljag = new RelayCommand<object>(ProvjeraPrtljaga, Provjera);
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

        public void PrijaviNaLet(object Parametar)
        {
            
            //Treba prijaviti putnika na let, tako sto se u karti oznaci atribut prijavljen na true
            //ako je prijava uspjesna izbacit messagebox
        }

        public void TraziKartu(object Parametar)
        {
            
            //Treba pronaci putnikovu kartu popuniti atribut PutnikInfo sa njegovim imenom i prezimenom
        }

        public void ProvjeraPrtljaga(object Parametar)
        {
            
            //Provjeriti da li je tezina dozvoljena tako sto se dobavi Linija leta iz nje avion i onda se provjeri
            //dozvoljena tezina prtljaga za dati avion
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
