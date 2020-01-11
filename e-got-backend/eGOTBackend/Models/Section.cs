using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Section
    {
        public Section()
        {
            Route = new HashSet<Route>();
        }

        public int Id { get; set; }
        public int StartLocation { get; set; }
        public int EndLocation { get; set; }
        public float Length { get; set; }
        public float ElevationGain { get; set; }
        public int Score { get; set; }
        public bool Status { get; set; }
        public int MountainRange { get; set; }

        public virtual Location EndLocationNavigation { get; set; }
        public virtual MountainRange MountainRangeNavigation { get; set; }
        public virtual Location StartLocationNavigation { get; set; }
        public virtual ICollection<Route> Route { get; set; }
    }
}
