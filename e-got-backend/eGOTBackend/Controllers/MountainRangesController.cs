using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using eGOTBackend.Repostiories;
using Microsoft.EntityFrameworkCore;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MountainRangesController : ApiController
    {
        [HttpGet]
        [ActionName("getAll")]
        public List<MountainRangeViewModel> Test()
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

                mountainRanges.Sort((a, b) => a.MountainSystem.Id.CompareTo(b.MountainSystem.Id));

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
