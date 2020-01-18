using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class DepartmentWorker
    {
        public int IdUser { get; set; }

        public virtual Users IdUserNavigation { get; set; }
    }
}
