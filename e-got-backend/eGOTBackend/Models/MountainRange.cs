﻿using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class MountainRange : IEntity
    {
        public MountainRange()
        {
            Permission = new HashSet<Permission>();
            Section = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MountainSystem { get; set; }


        public virtual MountainSystem MountainSystemNavigation { get; set; }
        public virtual ICollection<Permission> Permission { get; set; }
        public virtual ICollection<Section> Section { get; set; }
    }
}
