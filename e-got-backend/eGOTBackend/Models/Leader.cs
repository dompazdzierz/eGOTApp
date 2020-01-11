using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Leader
    {
        public Leader()
        {
            Permission = new HashSet<Permission>();
        }

        public int IdUser { get; set; }

        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
