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
using Microsoft.WindowsAzure.MobileServices;
using System.Data.SqlClient;



using Aerodrom.Helper;
using System.Runtime.CompilerServices;

namespace Aerodrom.ViewModel
{
    public class AdministratorViewModel : INotifyPropertyChanged
    {
        private ICommand izlaz;
        private INavigationService navigationService;
        //Tabele iz baze
        IMobileServiceTable<Uposlenik> tableUposlenici = App.MobileService.GetTable<Uposlenik>();
        IMobileServiceTable<Aviokompanija> tableAviokompanije = App.MobileService.GetTable<Aviokompanija>();
        IMobileServiceTable<Linija> tableLinije = App.MobileService.GetTable<Linija>();
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
        ObservableCollection<string> uposlenici = new ObservableCollection<string>();
        List<Uposlenik> ucitaniUposlenici = new List<Uposlenik>();
        string plata;
        string odabraniUposlenik = null;
        Pozicija selektovanaPozicija;
        ICommand obrisiUposlenika;
        ICommand dodajIzmjeniUpslenika;
        ICommand ponistiUposlenika;

        //Upravljanje aviokompanijama

        string nazivAviokompanije;
        string kontakOsobaAviokompanije;
        string emailAviokompanije;
        string telefonAviokompanije;
        string odabranaAviokompanija = null;
        ObservableCollection<string> aviokompanije = new ObservableCollection<string>();
        List<Aviokompanija> ucitaneAviokompanije = new List<Aviokompanija>();
        ICommand obrisiAviokompaniju;
        ICommand dodajIzmjeniAviokompaniju;
        ICommand ponistiAviokompaniju;

        //Upravljanje linijama (moze se dodati neka iz odobrenih zahtjeva od uprave, ili obrisati postojeca)

        ObservableCollection<string> postojeceLinije = new ObservableCollection<string>();
        List<Linija> ucitanePostojeceLinije = new List<Linija>();
        ObservableCollection<string> odobreneLinije = new ObservableCollection<string>();
        ICommand prikaziLinije;
        ICommand dodajLiniju;
        ICommand obrisiLiniju;
        string odabranaAviokompanijaLinije = null;
        string odabranaLinijaZaDodat = null;
        string odabranaLinijaZaObrisat = null;



        // /////////////////////////////////// GETERI I SETERI //////////////////////////////////////////////////

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
        public Pozicija SelektovanaPozicija
        {
            get => selektovanaPozicija; set
            {
                selektovanaPozicija = value;
                OnNotifyPropertyChanged("SelektovanaPozicija");
            }
        }
        public ObservableCollection<string> Uposlenici { get => uposlenici; set => uposlenici = value; }
        public string NazivAviokompanije { get => nazivAviokompanije; set => nazivAviokompanije = value; }
        public string KontakOsobaAviokompanije { get => kontakOsobaAviokompanije; set => kontakOsobaAviokompanije = value; }
        public string EmailAviokompanije { get => emailAviokompanije; set => emailAviokompanije = value; }
        public string TelefonAviokompanije { get => telefonAviokompanije; set => telefonAviokompanije = value; }
        public ObservableCollection<string> Aviokompanije { get => aviokompanije; set => aviokompanije = value; }
        public ICommand ObrisiAviokompaniju { get => obrisiAviokompaniju; set => obrisiAviokompaniju = value; }
        public ICommand DodajIzmjeniAviokompaniju { get => dodajIzmjeniAviokompaniju; set => dodajIzmjeniAviokompaniju = value; }
        public ICommand PonistiAviokompaniju { get => ponistiAviokompaniju; set => ponistiAviokompaniju = value; }
        public string OdabranaAviokompanija
        {
            get => odabranaAviokompanija; set
            {
                odabranaAviokompanija = value;
                OnNotifyPropertyChanged("OdabranaAviokompanija");
            }
        }
        public ObservableCollection<string> PostojeceLinije { get => postojeceLinije; set => postojeceLinije = value; }
        public ObservableCollection<string> OdobreneLinije { get => odobreneLinije; set => odobreneLinije = value; }
        public ICommand PrikaziLinije { get => prikaziLinije; set => prikaziLinije = value; }
        public ICommand DodajLiniju { get => dodajLiniju; set => dodajLiniju = value; }
        public ICommand ObrisiLiniju { get => obrisiLiniju; set => obrisiLiniju = value; }
       
        public string OdabranaLinijaZaDodat { get => odabranaLinijaZaDodat; set => odabranaLinijaZaDodat = value; }
        public string OdabranaLinijaZaObrisat { get => odabranaLinijaZaObrisat; set => odabranaLinijaZaObrisat = value; }
        public string OdabranaAviokompanijaLinije { get => odabranaAviokompanijaLinije; set => odabranaAviokompanijaLinije = value; }



        // ///////////////////////////////////////// G E T E R I    I    S E T E R I  //////////////////////////////////////////////////

        public AdministratorViewModel()
        {
            Izlaz = new RelayCommand<object>(Odjava, Provjera);

            SpasiPromjene = new RelayCommand<object>(IzmjenaInfo, ProvjeraInfo);

            ObrisiUposlenika = new RelayCommand<object>(BrisanjeUposlenika, Provjera);
            DodajIzmjeniUpslenika = new RelayCommand<object>(DodavanjeIzmjenaUposlenika, ProvjeraUposlenika);
            PonistiUposlenika = new RelayCommand<object>(PonistiPoljaUposlenika, Provjera);

            ObrisiAviokompaniju = new RelayCommand<object>(BrisanjeAviokompanije, Provjera);
            DodajIzmjeniAviokompaniju = new RelayCommand<object>(DodavanjeIzmjenaAviokompanije, ProvjeraAviokompanije);
            PonistiAviokompaniju = new RelayCommand<object>(PonistiPoljaAviokompanije, Provjera);

            PrikaziLinije = new RelayCommand<object>(PrikazLinija, Provjera);
            DodajLiniju = new RelayCommand<object>(DodavanjeLinije, Provjera);
            ObrisiLiniju = new RelayCommand<object>(BrisanjeLinije, Provjera);

            NavigationService = new NavigationService();

            //Treba popuniti ObservalCollection uposlenici iz baze sa stringovima imenima uposlenika
            PopuniUposlenicimaIzBaze();
            //Treba popuniti ObservalCollection aviokompanije iz baze sa stringovima nazivima aviokompanija
            PopuniAviokompanijamaIzBaze();
        }

        // ///////// METODE ZA UPRAVLJANJE UPOSLENICIMA ////////////

        public void BrisanjeUposlenika(object Parametar)
        {
            //Implementirati brisanje odabranog uposlenika iz baze
            //Naziv odabranog uposlenika je u varijabli OdabraniUposlenik
            if (odabraniUposlenik != null)
            {
                Uposlenik x = new Uposlenik();
                for (int i = 0; i < ucitaniUposlenici.Count; i++)
                {
                    if (ucitaniUposlenici[i].Ime.Equals(odabraniUposlenik))
                    {
                        x = ucitaniUposlenici[i]; break;
                    }
                }
                try
                {
                    tableUposlenici.DeleteAsync(x);
                    ucitaniUposlenici.Remove(x);
                    uposlenici.Remove(odabraniUposlenik);
                    MessageDialog msgDialog = new MessageDialog("Uposlenik je uspjesno obrisan!");
                    msgDialog.ShowAsync();
                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                    msgDialogError.ShowAsync();
                }
            }
        }

        public void DodavanjeIzmjenaUposlenika(object Parametar)
        {
            if (odabraniUposlenik == null)
            {
                //Implementirati Dodavanje novog uposlenika u bazu
                try
                {
                    Double plata;
                    Double.TryParse(Plata, out plata);
                    Uposlenik uposlenik = new Uposlenik(ime, prezime, DatumRodjenja.ToString(), telefon, email, plata,selektovanaPozicija);
                    //datum rodenja iz nekog razloga ne valja
                    tableUposlenici.InsertAsync(uposlenik);
                    PopuniUposlenicimaIzBaze();
                    MessageDialog msgDialog = new MessageDialog("Uposlenik je uspjesno unesen!");
                    msgDialog.ShowAsync();
                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                    msgDialogError.ShowAsync();
                }
            }
            else
            {
                //odabrani uposlenik je ime odabranog u comboboxu sa strane i treba ga izmjeniti u bazi sa novim podacima koji su uneseni
                Uposlenik x = new Uposlenik();
                for (int i = 0; i < ucitaniUposlenici.Count; i++)
                {
                    if (ucitaniUposlenici[i].Ime.Equals(odabraniUposlenik))
                    {
                        x = ucitaniUposlenici[i]; break;
                    }
                }
                try
                {
                    if(!String.IsNullOrEmpty(ime)) x.Ime = ime;
                    if (!String.IsNullOrEmpty(prezime)) x.Prezime = prezime;
                    x.DatumRodjenja = DatumRodjenja.ToString();//datum rodenja za test, sto ne radi...
                    if (!String.IsNullOrEmpty(telefon)) x.Telefon = telefon;
                    if (!String.IsNullOrEmpty(email)) x.Email = email;
                    if (!String.IsNullOrEmpty(Plata)) {
                        Double plata;
                        Double.TryParse(Plata, out plata);
                        x.Plata = plata;
                    }
                    x.Pozicija = selektovanaPozicija;
                    tableUposlenici.UpdateAsync(x);
                    if (!String.IsNullOrEmpty(ime))
                    {
                        uposlenici.Remove(odabraniUposlenik); uposlenici.Add(ime);
                    }
                    MessageDialog msgDialog = new MessageDialog("Uposlenik je uspjesno izmijenjen!");
                    msgDialog.ShowAsync();
                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                    msgDialogError.ShowAsync();
                }
            }
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

            if (Ime == "" || Prezime == "" || Email == "" || Telefon == "" || Plata == "")
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

                     // ////////////// METODE ZA UPRAVLJANJE AVIKOMPANIJAMA ///////////////


        public void BrisanjeAviokompanije(object Parametar)
        {
            if (odabranaAviokompanija != null)
            {
                Aviokompanija x = new Aviokompanija();
                for (int i = 0; i < ucitaneAviokompanije.Count; i++)
                {
                    if (ucitaneAviokompanije[i].Naziv.Equals(odabranaAviokompanija))
                    {
                        x = ucitaneAviokompanije[i]; break;
                    }
                }
                try
                {
                    tableAviokompanije.DeleteAsync(x);
                    ucitaneAviokompanije.Remove(x);
                    aviokompanije.Remove(odabranaAviokompanija);
                    MessageDialog msgDialog = new MessageDialog("Aviokompanija je uspjesno obrisana!");
                    msgDialog.ShowAsync();
                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                    msgDialogError.ShowAsync();
                }
            }
        }

        public void DodavanjeIzmjenaAviokompanije(object Parametar)
        {
            //Treba implementirati dodavanja nove avikompanije u bazu
            if (odabranaAviokompanija == null)
            {
                try
                {
                    Aviokompanija aviokompanija = new Aviokompanija(nazivAviokompanije, kontakOsobaAviokompanije, telefonAviokompanije, emailAviokompanije);
                    tableAviokompanije.InsertAsync(aviokompanija);
                    PopuniAviokompanijamaIzBaze();
                    MessageDialog msgDialog = new MessageDialog("Aviokompanija je uspjesno unesena!");
                    msgDialog.ShowAsync();
                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                    msgDialogError.ShowAsync();
                }
            }
            else
            {
                Aviokompanija x = new Aviokompanija();
                for (int i = 0; i < ucitaneAviokompanije.Count; i++)
                {
                    if (ucitaneAviokompanije[i].Naziv.Equals(odabranaAviokompanija))
                    {
                        x = ucitaneAviokompanije[i]; break;
                    }
                }
                try
                {
                    if (!String.IsNullOrEmpty(nazivAviokompanije)) x.Naziv = nazivAviokompanije;
                    if (!String.IsNullOrEmpty(kontakOsobaAviokompanije)) x.KontaktOsoba = kontakOsobaAviokompanije;
                    if (!String.IsNullOrEmpty(TelefonAviokompanije)) x.Telefon = TelefonAviokompanije;
                    if (!String.IsNullOrEmpty(emailAviokompanije)) x.Email = emailAviokompanije;
                    tableAviokompanije.UpdateAsync(x);
                    if (!String.IsNullOrEmpty(nazivAviokompanije))
                    {
                        aviokompanije.Remove(odabranaAviokompanija); aviokompanije.Add(nazivAviokompanije);
                    }
                    MessageDialog msgDialog = new MessageDialog("Aviokompanija je uspjesno izmijenjena!");
                    msgDialog.ShowAsync();
                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                    msgDialogError.ShowAsync();
                }
            }

        }

        public void PonistiPoljaAviokompanije(object Parametar)
        {
            NazivAviokompanije = String.Empty;
            OnNotifyPropertyChanged("NazivAviokompanije");
            KontakOsobaAviokompanije = String.Empty;
            OnNotifyPropertyChanged("KontakOsobaAviokompanije");
            TelefonAviokompanije = String.Empty;
            OnNotifyPropertyChanged("TelefonAviokompanije");
            EmailAviokompanije = String.Empty;
            OnNotifyPropertyChanged("EmailAviokompanije");
              
        }

        public bool ProvjeraAviokompanije(object Parametar)
        {
            //Ako ima nekih restrikcija treba ih dodat za polja
            return true;
        }

        // //////////////////// METODE ZA UPRAVLJANJE LINIJAMA ///////////////////////

        public void PrikazLinija(object Parametar)
        {
            /*za test
            List<Dan> d = new List<Dan>();d.Add(Dan.Cetvrtak);
            Linija l = new Linija("545", "bec", "944cc9df-ec77-4bda-9ebe-5c8b188fb860", "5", 1, 1000, d, d, "14:00", "15:00", true);
            try { tableLinije.InsertAsync(l); MessageDialog msgDialog = new MessageDialog("Linija je uspjesno unesena!");
                msgDialog.ShowAsync();
            }
             catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                msgDialogError.ShowAsync();
            }*/
            //Treba ucitati sve dostupne stringove linije odabrane aviokompanije iz baze
            //Naziv aviokompanije je u varijabli OdabranaAvikompanijaLinije
            string id=null;
            foreach(Aviokompanija x in ucitaneAviokompanije)
            {
                if (x.Naziv == odabranaAviokompanijaLinije)
                {
                    id = x.Id;break;
                }
            }
            //U ObservalCollection PostojeceLinije ucitavaju se linije koje aviokompanija vec ima
            if (id != null) PopuniLinijamaIzBaze(id);
            // U OservalCollection odobreneLinije su one koje je uprava odobrila (odobren zahtjev za novu liniju) koju onda admin moze dodat

        }
        public void DodavanjeLinije(object Parametar)
        {
           
            //Treba u bazu dodati liniju koja se odabrala, njen ID il sta se vec ucitalo je u varijabli odabranaLinijaZaDodat
        }
        public void BrisanjeLinije(object Parametar)
        {
            //Treba iz baze obrisati liniju koja se odabrala, njen ID il sta se vec ucitalo je u varijabli odabranaLinijaZaObrisat
        }

        // //////// UPRAVLJANJE POCETNOM ////////////
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
        //Za popunjavanje uposlenicima iz baze
        private async void PopuniUposlenicimaIzBaze()
        {
            ucitaniUposlenici=await tableUposlenici.ToListAsync();
            for(int i = 0; i < ucitaniUposlenici.Count; i++)
            {
                if (!uposlenici.Contains(ucitaniUposlenici[i].Ime))
                {
                    uposlenici.Add(ucitaniUposlenici[i].Ime);
                }
            }
        }
        //Za popunjavanje aviokompanijama iz baze
        private async void PopuniAviokompanijamaIzBaze()
        {
            ucitaneAviokompanije = await tableAviokompanije.ToListAsync();
            for (int i = 0; i < ucitaneAviokompanije.Count; i++)
            {
                if (!aviokompanije.Contains(ucitaneAviokompanije[i].Naziv))
                {
                    aviokompanije.Add(ucitaneAviokompanije[i].Naziv);
                }
            }
        }
        //Za popunjavanje linijam iz baze
        private async void PopuniLinijamaIzBaze(string idAviokompanije)
        {
            ucitanePostojeceLinije = await tableLinije.Where((Linija l) => l.IdAviokompanije == idAviokompanije).ToListAsync();
            for (int i = 0; i < ucitanePostojeceLinije.Count; i++)
            {
                string x = ucitanePostojeceLinije[i].Destinacija + ", br linije: " + ucitanePostojeceLinije[i].BrojLinije;
                if (!postojeceLinije.Contains(x)) postojeceLinije.Add(x);
            }
        }

    }


}
