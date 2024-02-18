using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Login
    {
        private string _User;
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        private string _Contraseña;
        public string password
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }
    }
}
