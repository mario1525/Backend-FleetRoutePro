using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class UsersModels
    {
        public string ID { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public DateTime FechaLog { get; set; }
    }
}