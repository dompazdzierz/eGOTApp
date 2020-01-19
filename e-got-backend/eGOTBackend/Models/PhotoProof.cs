using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class PhotoProof : IEntity
    {
        public int Id { get; set; }
        public int IdTrip { get; set; }
        public byte[] Photo { get; set; }

        public virtual Trip IdTripNavigation { get; set; }
    }
}
