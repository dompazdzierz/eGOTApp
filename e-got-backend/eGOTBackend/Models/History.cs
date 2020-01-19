using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class History : IEntity
    {
        public int IdTurist { get; set; }
        public int IdBadgeLevel { get; set; }
        public DateTime Date { get; set; }

        public virtual BadgeLevel IdBadgeLevelNavigation { get; set; }
        public virtual Tourist IdTuristNavigation { get; set; }
    }
}
