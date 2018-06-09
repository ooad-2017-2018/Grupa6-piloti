using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Aerodrom.Helper;
using System.Runtime.CompilerServices;



namespace Aerodrom.ViewModel
{
    class UpravaViewModel : INotifyPropertyChanged
    {
        private ICommand izlaz;
        private INavigationService navigationService;

        ObservableCollection<string> zahtjeviOdgoda = new ObservableCollection<string>();
        string odabraniZahtjev=null;
        string detaljiZahtjeva;
        string detaljiOdgode;
        ICommand prikaziDetalje;
        ICommand obrisiZahtjev;
        ICommand odobriZahtjev;

        ObservableCollection<string> zahtjeviLinije = new ObservableCollection<string>();
        string odabraniZahtjevLinija = null;
        string detaljiZahtjevaLinija;
        string detaljiOdgodeLinija;
        ICommand prikaziDetaljeLinija;
        ICommand obrisiZahtjevLinija;
        ICommand odobriZahtjevLinija;

        public ICommand Izlaz { get => izlaz; set => izlaz = value; }
        public ObservableCollection<string> ZahtjeviOdgoda { get => zahtjeviOdgoda; set => zahtjeviOdgoda = value; }
        public string OdabraniZahtjev { get => odabraniZahtjev; set => odabraniZahtjev = value; }
        public string DetaljiZahtjeva { get => detaljiZahtjeva; set => detaljiZahtjeva = value; }
        public string DetaljiOdgode { get => detaljiOdgode; set => detaljiOdgode = value; }
        public ICommand PrikaziDetalje { get => prikaziDetalje; set => prikaziDetalje = value; }
        public ICommand ObrisiZahtjev { get => obrisiZahtjev; set => obrisiZahtjev = value; }
        public ICommand OdobriZahtjev { get => odobriZahtjev; set => odobriZahtjev = value; }
        internal INavigationService NavigationService { get => navigationService; set => navigationService = value; }
        public ObservableCollection<string> ZahtjeviLinije { get => zahtjeviLinije; set => zahtjeviLinije = value; }
        public string OdabraniZahtjevLinija { get => odabraniZahtjevLinija; set => odabraniZahtjevLinija = value; }
        public string DetaljiZahtjevaLinija { get => detaljiZahtjevaLinija; set => detaljiZahtjevaLinija = value; }
        public string DetaljiOdgodeLinija { get => detaljiOdgodeLinija; set => detaljiOdgodeLinija = value; }
        public ICommand PrikaziDetaljeLinija { get => prikaziDetaljeLinija; set => prikaziDetaljeLinija = value; }
        public ICommand ObrisiZahtjevLinija { get => obrisiZahtjevLinija; set => obrisiZahtjevLinija = value; }
        public ICommand OdobriZahtjevLinija { get => odobriZahtjevLinija; set => odobriZahtjevLinija = value; }

        public UpravaViewModel()
        {
            //Treba u observalcollectione zahtjevLinije i zahtjeviOdgode ucitati sve trenutne zahtjeve koji nisu obradjeni iz baze

            Izlaz = new RelayCommand<object>(Odjava, Provjera);
            NavigationService = new NavigationService();

            PrikaziDetalje = new RelayCommand<object>(PrikazDetaljaZahtjevaOdgode, Provjera);
            ObrisiZahtjev = new RelayCommand<object>(BrisanjezahtjevaOdgode, Provjera);
            OdobriZahtjev = new RelayCommand<object>(OdobravanjeZahtjevaOdgode, Provjera);

            PrikaziDetaljeLinija = new RelayCommand<object>(PrikazDetaljaLinije, Provjera);
            ObrisiZahtjevLinija = new RelayCommand<object>(BrisanjezahtjevaLinije, Provjera);
            OdobriZahtjevLinija = new RelayCommand<object>(OdobravanjeZahtjevaLinije, Provjera);


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

        public void PrikazDetaljaZahtjevaOdgode(object Parametar)
        {
            //Treba na osnovu toga koji je zahtjev izabran -> OdabraniZahtjev u varijablu DetaljiZahtjeva iz baze ucitat detalje
        }

        public void BrisanjezahtjevaOdgode(object Parametar)
        {
            //Treba odabrani zahtjev u bazi oznacit kao obradjen i odbijen (atributi zahtjeva)
        }

        public void OdobravanjeZahtjevaOdgode(object Parametar)
        {
            //Oznacit odabrani zahtjev kao obradjen i odobren u bazi
        }

        public void PrikazDetaljaLinije(object Parametar)
        {
            //Treba na osnovu toga koji je zahtjev odabran ->OdabraniZahtjevLinija u varijablu DetaljiZahtjevaLinija iz baze ucitat detalje o letu
        }
        public void BrisanjezahtjevaLinije(object Parametar)
        {
            //Treba odabrani zahtjev u bazi oznacit kao obradjen i odbijen (atributi zahtjeva)
        }

        public void OdobravanjeZahtjevaLinije(object Parametar)
        {
            //Oznacit odabrani zahtjev kao obradjen i odobren u bazi
        }
    

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
