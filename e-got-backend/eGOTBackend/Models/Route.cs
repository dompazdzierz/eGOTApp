using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję trasy.
    /// </summary>
    public partial class Route : IEntity
    {
        public int Id { get; set; }
        public int IdTrip { get; set; }
        public int IdSection { get; set; }
        public int PositionInTrip { get; set; }

        public virtual Section IdSectionNavigation { get; set; }
        public virtual Trip IdTripNavigation { get; set; }
    }
}
