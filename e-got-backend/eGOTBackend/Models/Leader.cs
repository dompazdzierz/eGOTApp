using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję przodownika.
    /// </summary>
    public partial class Leader : IEntity
    {
        public Leader()
        {
            Permission = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }

        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
