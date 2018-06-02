using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.ViewModel
{
    class LoginViewModel
    {
        private AdministratorViewModel parent1;
        private CheckInViewModel parent2;
        private UpravaViewModel parent3;
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

        public AdministratorViewModel Parent1 { get => parent1; set => parent1 = value; }
        public CheckInViewModel Parent2 { get => parent2; set => parent2 = value; }
        internal UpravaViewModel Parent3 { get => parent3; set => parent3 = value; }
    }
}
