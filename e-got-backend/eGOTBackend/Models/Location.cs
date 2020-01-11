using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Location
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
