using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję odcinka.
    /// </summary>
    [DataContract]
    public partial class Section : IEntity
    {
        public Section()
        {
            Routes = new HashSet<Route>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "startLocationId")]
        public int StartLocationId { get; set; }
        [DataMember(Name = "endLocationId")]
        public int EndLocationId { get; set; }
        [DataMember(Name = "length")]
        public float Length { get; set; }
        [DataMember(Name = "elevationGain")]
        public float ElevationGain { get; set; }
        [DataMember(Name = "score")]
        public int Score { get; set; }
        [DataMember(Name = "status")]
        public bool Status { get; set; }
        [DataMember(Name = "mountainRangeId")]
        public int MountainRangeId { get; set; }

        public virtual Location EndLocation { get; set; }
        public virtual MountainRange MountainRange { get; set; }
        public virtual Location StartLocation { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
