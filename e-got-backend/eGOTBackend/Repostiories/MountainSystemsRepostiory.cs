using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eGOTBackend.Repostiories
{
    public class MountainSystemsRepository
    {
        public List<MountainSystemViewModel> GetAll()
        {
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    List<MountainSystem> mountainSystems = new List<MountainSystem>();
                    mountainSystems = dbContext.MountainSystem.AsNoTracking()
                        .Include(x => x.MountainRanges)
                        .ToList();

                    if (mountainSystems == null)
                    {
                        return null;
                    }

                    mountainSystems.Sort((a, b) => a.Id.CompareTo(b.Id));

                    List<MountainSystemViewModel> mountainSystemViewModels = new List<MountainSystemViewModel>();
                    foreach (var x in mountainSystems)
                    {
                        var mountainSystemViewModel = new MountainSystemViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            MountainRanges = x.MountainRanges
                        };
                        mountainSystemViewModels.Add(mountainSystemViewModel);
                    }

                    return mountainSystemViewModels;
                }
            }
        }
    }
}