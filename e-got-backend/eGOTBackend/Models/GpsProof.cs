using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class GpsProof : IEntity
    {
        public int Id { get; set; }
        public int IdTrip { get; set; }
        public string GpsDataUrl { get; set; }

        public virtual Trip IdTripNavigation { get; set; }
    }
}
