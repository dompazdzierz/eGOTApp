using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję punktu geograficznego.
    /// </summary>
    public partial class Location : IEntity
    {
        public Location()
        {
            SectionEndLocationNavigation = new HashSet<Section>();
            SectionStartLocationNavigation = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float Longtitude { get; set; }
        public float Latitude { get; set; }

        public virtual ICollection<Section> SectionEndLocationNavigation { get; set; }
        public virtual ICollection<Section> SectionStartLocationNavigation { get; set; }
    }
}
