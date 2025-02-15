﻿using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję historii turysty.
    /// </summary>
    public partial class History : IEntity
    {
        public int Id { get; set; }
        public int IdTourist { get; set; }
        public int IdBadgeLevel { get; set; }
        public DateTime Date { get; set; }

        public virtual BadgeLevel IdBadgeLevelNavigation { get; set; }
        public virtual Tourist IdTouristNavigation { get; set; }
    }
}
