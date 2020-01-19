using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class BadgeLevel
    {
        public BadgeLevel()
        {
            History = new HashSet<History>();
            Tourist = new HashSet<Tourist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RequiredPoints { get; set; }
        public byte[] Icon { get; set; }

        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Tourist> Tourist { get; set; }
    }
}
