using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class VehiclesModels
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public int Capacity { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<RouteModels> RouteModels { get; set; }
    }
}
