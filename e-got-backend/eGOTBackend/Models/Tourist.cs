using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję turysty.
    /// </summary>
    public partial class Tourist : IEntity
    {
        public Tourist()
        {
            History = new HashSet<History>();
            Trip = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDisabled { get; set; }
        public int AllPoints { get; set; }
        public int ConfirmedPoints { get; set; }
        public int IdBadgeLevel { get; set; }

        public virtual BadgeLevel IdBadgeLevelNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Trip> Trip { get; set; }
    }
}
