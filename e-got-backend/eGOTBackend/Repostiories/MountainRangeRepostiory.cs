using eGOTBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eGOTBackend.Repostiories
{
    public class MountainRangeRepostiory
    {
        public List<MountainRangeViewModel> GetMountainRanges()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                List<MountainRange> mountainRanges = new List<MountainRange>();
                mountainRanges = dbContext.MountainRange.AsNoTracking()
                    .Include(x => x.MountainSystem)
                    .ToList();

                if (mountainRanges == null)
                {
                    return null;
                }

                List<MountainRangeViewModel> mountainRangeViewModels = new List<MountainRangeViewModel>();
                foreach (var x in mountainRanges)
                {
                    var mountainRangeViewModel = new MountainRangeViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        MountainSystemName = x.MountainSystem.Name
                    };
                    mountainRangeViewModels.Add(mountainRangeViewModel);
                }

                return mountainRangeViewModels;
            }
        }
    }
}