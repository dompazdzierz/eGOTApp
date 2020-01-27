using System.Runtime.Serialization;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa reprezentjąca View Model grupy górskiej oraz łańcucha górskiego,
    /// w której ta grupa górska się znajduje.
    /// </summary>
    [DataContract]
    public class MountainRangeViewModel : IEntity
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "mountainSystemName")]
        public string MountainSystemName { get; set; }
    }
}