using System.Collections.Generic;

namespace eGOTBackend.Models
{
    public partial class MountainSystem : IEntity
    {
        public MountainSystem()
        {
            MountainRanges = new HashSet<MountainRange>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MountainRange> MountainRanges { get; set; }
    }
}