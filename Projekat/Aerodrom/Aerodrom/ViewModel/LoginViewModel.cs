using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.ViewModel
{
    class LoginViewModel
    {
        private AdministratorViewModel parent;
        public LoginViewModel(AdministratorViewModel parent)
        {
            this.Parent = parent;
        }

        public AdministratorViewModel Parent { get => parent; set => parent = value; }
    }
}
