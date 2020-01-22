using eGOTBackend.Models.ViewModels;
using eGOTBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                .Include(x => new { x.EndLocation, x.StartLocation, x.MountainRange })
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
    }
}