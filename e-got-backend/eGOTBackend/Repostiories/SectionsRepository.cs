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

        public void Set(int id, int startLocationId, int endLocationId,
            float length, float elevationGain, int score, int mountainRangeId)
        {
            dbContext.Section.Update(new Section
            {
                Id = id,
                StartLocationId = startLocationId,
                EndLocationId = endLocationId,
                Length = length,
                ElevationGain = elevationGain,
                Score = score,
                Status = true,
                MountainRangeId = mountainRangeId
            });
            dbContext.SaveChanges();
        }

        public void AddElement(int startLocationId, int endLocationId,
            float length, float elevationGain, int score, int mountainRangeId, bool status = true)
        {
            dbContext.Section.Add(new Section
            {
                StartLocationId = startLocationId,
                EndLocationId = endLocationId,
                Length = length,
                ElevationGain = elevationGain,
                Score = score,
                Status = status,
                MountainRangeId = mountainRangeId
            });
            dbContext.SaveChanges();
        }

        public void RemoveElement(int id)
        {
            dbContext.Section.Remove(new Section
            {
                Id = id
            });
            dbContext.SaveChanges();
        }

        public void Accept(int id)
        {
            Section section = new Section
            {
                Id = id,
                Status = true,
            };

            dbContext.Section.Attach(section);
            dbContext.Entry(section).Property(x => x.Status).IsModified = true;
            dbContext.SaveChanges();
        }
    }
}