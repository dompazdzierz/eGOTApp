using System.Runtime.Serialization;

namespace eGOTBackend.Models.ViewModels
{
    [DataContract]
    public class SectionViewModel : IEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "startLocation")]
        public string StartLocation { get; set; }
        [DataMember(Name = "endLocation")]
        public string EndLocation { get; set; }
        [DataMember(Name = "length")]
        public float Length { get; set; }
        [DataMember(Name = "elevationGain")]
        public float ElevationGain { get; set; }
        [DataMember(Name = "score")]
        public int Score { get; set; }
        [DataMember(Name = "status")]
        public bool Status { get; set; }
        [DataMember(Name = "mountainRange")]
        public string MountainRange { get; set; }
    }
}