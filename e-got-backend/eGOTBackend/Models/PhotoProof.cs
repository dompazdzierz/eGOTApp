using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję dowodu fotograficznego.
    /// </summary>
    public partial class PhotoProof : IEntity
    {
        public int Id { get; set; }
        public int IdTrip { get; set; }
        public string PhotoUrl { get; set; }

        public virtual Trip IdTripNavigation { get; set; }
    }
}
