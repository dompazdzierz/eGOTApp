using System;
using System.Runtime.Serialization;

namespace WebApplication2.Controllers
{
    [DataContract]
    public class Todo
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "dueDate")]
        public DateTime? DueDate { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "done")]
        public bool Done { get; set; }
    }
}