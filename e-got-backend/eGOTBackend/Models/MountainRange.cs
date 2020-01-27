using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję grupy górskiej.
    /// </summary>
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class MountainRange : IEntity
    {
        public MountainRange()
        {
            Permission = new HashSet<Permission>();
            Section = new HashSet<Section>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "mountainSystemId")]
        public int MountainSystemId { get; set; }

        public virtual MountainSystem MountainSystem { get; set; }
        public virtual ICollection<Permission> Permission { get; set; }
        public virtual ICollection<Section> Section { get; set; }
    }
}
