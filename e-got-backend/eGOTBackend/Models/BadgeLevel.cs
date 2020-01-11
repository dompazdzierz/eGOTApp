using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class BadgeLevel
    {
        public BadgeLevel()
        {
            History = new HashSet<History>();
            Turist = new HashSet<Turist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RequiredPoints { get; set; }
        public byte[] Icon { get; set; }

        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Turist> Turist { get; set; }
    }
}
