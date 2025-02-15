﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentująca encję łańcucha górskiego.
    /// </summary>
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class MountainSystem : IEntity
    {
        public MountainSystem()
        {
            MountainRanges = new HashSet<MountainRange>();
        }
        
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "mountainRanges")]
        public virtual ICollection<MountainRange> MountainRanges { get; set; }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}