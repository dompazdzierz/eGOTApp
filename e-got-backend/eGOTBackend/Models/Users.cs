using System;
using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class Users : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastSeen { get; set; }

        public virtual CommissionWorker CommissionWorker { get; set; }
        public virtual DepartmentWorker DepartmentWorker { get; set; }
        public virtual Leader Leader { get; set; }
        public virtual Tourist Turist { get; set; }
    }
}
