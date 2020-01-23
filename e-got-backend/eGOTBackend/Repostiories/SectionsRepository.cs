using eGOTBackend.Models.ViewModels;
using eGOTBackend.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eGOTBackend.Repostiories
{
    public class SectionsRepository : BaseRepository
    {
        public List<SectionViewModel> GetAll(int mountainRangeId, bool status)
        {
            var sections = new List<Section>();
            sections = dbContext.Section
                .Where(x => x.MountainRangeId == mountainRangeId && x.Status == status)
                .Include(x => x.EndLocation).Include(x => x.StartLocation).Include(x => x.MountainRange)
                .ToList();

            if (sections == null)
            {
                return null;
            }

            List<SectionViewModel> sectionViewModels = new List<SectionViewModel>();
            foreach (var x in sections)
            {
                var sectionViewModel = new SectionViewModel()
                {
                    Id = x.Id,
                    StartLocation = x.StartLocation.Name,
                    EndLocation = x.EndLocation.Name,
                    Length = x.Length,
                    ElevationGain = x.ElevationGain,
                    Score = x.Score,
                    Status = x.Status,
                    MountainRange = x.MountainRange.Name
                };
                sectionViewModels.Add(sectionViewModel);
            }

            return sectionViewModels;           
        }

        public Section Get(int id)
        {
            var section = dbContext.Section
                .Where(x => x.Id == id)
                .Single();

            if (section == null)
            {
                return null;
            }

            return section;
        }
    }
}