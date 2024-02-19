using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RouteModels
    {
        public string Id { get; set; }
        public string Descriptionn { get; set; }
        public string DriverId { get; set; }
        public string VehicleId { get; set; }
        public bool Active { get; set; }

        public virtual DrivesModels DrivesModels { get; set; }
        public virtual VehiclesModels VehiclesModels { get; set; }
        public virtual ICollection<ScheduleModels> ScheduleModels { get; set; }


    }
}
