using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class GpsProof
    {
        public int IdTrip { get; set; }
        public byte[] GpsData { get; set; }

        public virtual Trip IdTripNavigation { get; set; }
    }
}
