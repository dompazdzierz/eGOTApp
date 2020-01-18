using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eGOTBackend.Models
{
    [DataContract]
    public partial class Section
    {
        public Section()
        {
            Route = new HashSet<Route>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "startLocation")]
        public int StartLocation { get; set; }
        [DataMember(Name = "endLocation")]
        public int EndLocation { get; set; }
        [DataMember(Name = "length")]
        public float Length { get; set; }
        [DataMember(Name = "elevationGain")]
        public float ElevationGain { get; set; }
        [DataMember(Name = "score")]
        public int Score { get; set; }
        [DataMember(Name = "status")]
        public bool Status { get; set; }
        [DataMember(Name = "mountainRange")]
        public int MountainRange { get; set; }

        public virtual Location EndLocationNavigation { get; set; }
        public virtual MountainRange MountainRangeNavigation { get; set; }
        public virtual Location StartLocationNavigation { get; set; }
        public virtual ICollection<Route> Route { get; set; }
    }
}
