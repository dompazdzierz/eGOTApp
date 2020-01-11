using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Route
    {
        public int IdTrip { get; set; }
        public int IdSection { get; set; }
        public int PositionInTrip { get; set; }

        public virtual Section IdSectionNavigation { get; set; }
        public virtual Trip IdTripNavigation { get; set; }
    }
}
