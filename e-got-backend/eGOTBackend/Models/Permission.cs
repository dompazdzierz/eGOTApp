using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class Permission : IEntity
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdMountainRange { get; set; }

        public virtual MountainRange IdMountainRangeNavigation { get; set; }
        public virtual Leader IdUserNavigation { get; set; }
    }
}
