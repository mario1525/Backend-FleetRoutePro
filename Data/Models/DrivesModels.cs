using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DrivesModels
    {
        public string ID { get; set; }
        public string Last_Name { get; set; }
        public string Firs_Name { get; set; }
        public string Ssn { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public BigInteger phone { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<RouteModels> RouteModels { get; set; }

    }
}
