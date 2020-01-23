using System.Collections.Generic;
using System.Linq;
using eGOTBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace eGOTBackend.Repostiories
{
    public class LocationsRepository : BaseRepository
    {
        public List<Location> GetAll()
        {
            var sections = dbContext.Location.ToList();

            if (sections == null)
            {
                return null;
            }

            return sections;
        }
    }
}