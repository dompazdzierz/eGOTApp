using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję dowodu GPS.
    /// </summary>
    public partial class GpsProof : IEntity
    {
        public int Id { get; set; }
        public int IdTrip { get; set; }
        public string GpsDataUrl { get; set; }

        public virtual Trip IdTripNavigation { get; set; }
    }
}
