using System.Runtime.Serialization;

namespace eGOTBackend.Models
{
    [DataContract]
    public class MountainRangeViewModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "mountainSystemName")]
        public string MountainSystemName { get; set; }
    }
}