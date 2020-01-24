using System.Runtime.Serialization;
using System.Collections.Generic;

namespace eGOTBackend.Models.ViewModels
{
    [DataContract]
    public class TripViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "startDate")]
        public string StartDate { get; set; }
        [DataMember(Name = "endDate")]
        public string EndDate { get; set; }
        [DataMember(Name = "score")]
        public int Score { get; set; }
        [DataMember(Name = "length")]
        public float Length { get; set; }
        [DataMember(Name = "elevationGain")]
        public float ElevationGain { get; set; }
        [DataMember(Name = "photos")]
        public ICollection<string> Photos { get; set; }
    }
}