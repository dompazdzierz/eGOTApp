using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class CommissionWorker : IEntity
    {
        public int Id { get; set; }
        public int IdUser { get; set; }

        public virtual Users IdUserNavigation { get; set; }
    }
}
