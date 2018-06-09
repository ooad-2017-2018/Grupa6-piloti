using System.Windows.Input;
using System.ComponentModel;
using Aerodrom.Helper;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

namespace Aerodrom.ViewModel
{
    class LoginViewModel 
    {
        private ICommand izlaz;
        ICommand login;
        string korisnickoIme;
        string lozinka;

        private AdministratorViewModel parent1;
        private CheckInViewModel parent2;
        private UpravaViewModel parent3;
        private AviokompanijaViewModel parent4;
        public LoginViewModel(AdministratorViewModel parent)
        {
            this.Parent1 = parent;
        }
        public LoginViewModel(CheckInViewModel parent)
        {
            this.Parent2=parent;
        }

        public LoginViewModel(UpravaViewModel parent)
        {
            this.Parent3 = parent;
        }

        public LoginViewModel(AviokompanijaViewModel parent)
        {
            this.Parent4 = parent;
        }

        public AdministratorViewModel Parent1 { get => parent1; set => parent1 = value; }
        public CheckInViewModel Parent2 { get => parent2; set => parent2 = value; }
        public ICommand Izlaz { get => izlaz; set => izlaz = value; }
        public ICommand Login { get => login; set => login = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        internal UpravaViewModel Parent3 { get => parent3; set => parent3 = value; }
        internal AviokompanijaViewModel Parent4 { get => parent4; set => parent4 = value; }

        public LoginViewModel()
        {
            Izlaz = new RelayCommand<object>(ZatvaranjeAplikacije, Provjera);
            Login = new RelayCommand<object>(LoginUsera, Provjera);
        }

        public void ZatvaranjeAplikacije(object Parametar)
        {
            Application.Current.Exit();
        }
        public void LoginUsera(object Parametar)
        {
            //Otvorit formu u zavisnosti ko je prijavljen na sistem
        }
        public bool Provjera(object Parametar)
        {
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
