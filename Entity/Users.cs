namespace Entity
{
    public class Users
    {
        public Users()
        {
        }
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }      

        private string _User;
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _Rol;
        public string Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }

        private bool _Estado;
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private bool _Eliminado;
        public bool Eliminado
        {
            get { return _Eliminado; }
            set { _Eliminado = value; }
        }

        private string _FechaLog;
        public string Fecha_log
        {
            get { return _FechaLog; }
            set { _FechaLog = value; }
        }
    }
}