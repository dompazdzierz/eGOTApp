using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Route = new HashSet<Route>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int Score { get; set; }
        public float Length { get; set; }
        public float ElevationGain { get; set; }
        public int IdTurist { get; set; }

        public virtual Turist IdTuristNavigation { get; set; }
        public virtual GpsProof GpsProof { get; set; }
        public virtual PhotoProof PhotoProof { get; set; }
        public virtual ICollection<Route> Route { get; set; }
    }
}
