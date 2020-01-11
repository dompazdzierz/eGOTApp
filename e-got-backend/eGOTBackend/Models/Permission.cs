using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Permission
    {
        public int IdUser { get; set; }
        public int IdMountainRange { get; set; }

        public virtual MountainRange IdMountainRangeNavigation { get; set; }
        public virtual Leader IdUserNavigation { get; set; }
    }
}
