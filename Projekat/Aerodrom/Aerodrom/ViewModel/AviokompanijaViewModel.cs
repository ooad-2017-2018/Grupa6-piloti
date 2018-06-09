using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Aerodrom.Helper;
using System.Runtime.CompilerServices;

namespace Aerodrom.ViewModel
{
    class AviokompanijaViewModel : INotifyPropertyChanged
    {

        private ICommand izlaz;
        private INavigationService navigationService;

        ObservableCollection<string> registrovaniLetovi = new ObservableCollection<string>();

        ObservableCollection<string> tipLeta = new ObservableCollection<string>();
        ObservableCollection<string> dani = new ObservableCollection<string>();
        ObservableCollection<string> avioni = new ObservableCollection<string>();
        string odabraniTip;
        string odabraniDan;
        string odabraniAvion;
        string destinacija;
        string vaziOd;
        string vaziDo;
        string cijenaTakse;
        string cijenaKarte;
        string porukaSistema;
        ICommand provjeriIzvodljivost;
        ICommand posaljiZahtjev;

        public ICommand Izlaz { get => izlaz; set => izlaz = value; }
        internal INavigationService NavigationService { get => navigationService; set => navigationService = value; }
        public ObservableCollection<string> RegistrovaniLetovi { get => registrovaniLetovi; set => registrovaniLetovi = value; }
        public ObservableCollection<string> TipLeta { get => tipLeta; set => tipLeta = value; }
        public ObservableCollection<string> Dani { get => dani; set => dani = value; }
        public ObservableCollection<string> Avioni { get => avioni; set => avioni = value; }
        public string OdabraniTip { get => odabraniTip; set => odabraniTip = value; }
        public string OdabraniDan { get => odabraniDan; set => odabraniDan = value; }
        public string OdabraniAvion { get => odabraniAvion; set => odabraniAvion = value; }
        public string Destinacija { get => destinacija; set => destinacija = value; }
        public string VaziOd { get => vaziOd; set => vaziOd = value; }
        public string VaziDo { get => vaziDo; set => vaziDo = value; }
        public string CijenaTakse { get => cijenaTakse; set => cijenaTakse = value; }
        public string CijenaKarte { get => cijenaKarte; set => cijenaKarte = value; }
        public string PorukaSistema { get => porukaSistema; set => porukaSistema = value; }
        public ICommand ProvjeriIzvodljivost { get => provjeriIzvodljivost; set => provjeriIzvodljivost = value; }
        public ICommand PosaljiZahtjev { get => posaljiZahtjev; set => posaljiZahtjev = value; }

        public AviokompanijaViewModel()
        {
            //Treba observalbleCollection registrovani letovi popuniti sa letovima koje ima aviokompanija
            //U OC avioni treba ucitati tipove aviona iz baze
            TipLeta.Add("Charter"); TipLeta.Add("Redovni");
            Dani.Add("Ponedeljak"); Dani.Add("Utorak"); Dani.Add("Srijeda"); Dani.Add("Cetvrtak"); Dani.Add("Petak"); Dani.Add("Subota"); Dani.Add("Nedelja");

            Izlaz = new RelayCommand<object>(Odjava, Provjera);
            NavigationService = new NavigationService();

            ProvjeriIzvodljivost = new RelayCommand<object>(ProvjeraIzvodljivosti, Provjera);
            PosaljiZahtjev = new RelayCommand<object>(SlanjeZahtjeva, Provjera);
        }

        public void ProvjeraIzvodljivosti(object Parametar)
        {
            //Treba pokupiti podatke iz stringova (atributa) i provjeriti u bazi da li postoji neki let u isto vrijeme kao ovaj na isti dan
            //i ispisat poruku ako nije moguce, a ako jeste potvrdu poruku
        }

        public void SlanjeZahtjeva(object Parametar)
        {
            //Treba kreirati novi zahtjv ako je gornja provjera prosla i smejstit ga u bazu
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


    }
}
