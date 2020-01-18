using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class MountainRange
    {
        public MountainRange()
        {
            Permission = new HashSet<Permission>();
            Section = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Permission> Permission { get; set; }
        public virtual ICollection<Section> Section { get; set; }
    }
}
