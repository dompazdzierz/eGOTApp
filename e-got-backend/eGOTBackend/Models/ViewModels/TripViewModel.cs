using System.Runtime.Serialization;
using System.Collections.Generic;

namespace eGOTBackend.Models.ViewModels
{
    /// <summary>
    /// Klasa reprezentująca View Model wycieczki.
    /// </summary>
    [DataContract]
    public class TripViewModel : IEntity
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
        [DataMember(Name = "route")]
        public string Route { get; set; }
        [DataMember(Name = "photos")]
        public ICollection<string> Photos { get; set; }
    }
}