﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ScheduleModels
    {
        public string Id { get; set; }
        public string RouteId { get; set; }
        public int WeekNum { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public bool Active { get; set; }

        public virtual RouteModels RouteModels { get; set; }
    }
}
