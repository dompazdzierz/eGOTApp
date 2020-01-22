using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eGOTBackend.Models.ViewModels
{
    [DataContract]
    public class MountainSystemViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "mountainRanges")]
        public ICollection<MountainRange> MountainRanges { get; set; }
    }
}