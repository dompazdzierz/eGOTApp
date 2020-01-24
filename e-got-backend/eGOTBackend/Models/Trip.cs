using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class Trip : IEntity
    {
        public Trip()
        {
            Route = new HashSet<Route>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int Score { get; set; }
        public float Length { get; set; }
        public float ElevationGain { get; set; }
        public int IdTourist { get; set; }

        public virtual Tourist IdTouristNavigation { get; set; }
        public virtual GpsProof GpsProof { get; set; }
        public virtual PhotoProof PhotoProof { get; set; }
        public virtual ICollection<Route> Route { get; set; }
    }
}
