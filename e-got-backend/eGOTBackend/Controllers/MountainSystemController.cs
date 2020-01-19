using System.Web.Http.Cors;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using eGOTBackend.Models;

namespace eGOTBackend.Controllers
{
    [RoutePrefix("mountain-systems")]
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class MountainSystemController: ApiController
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<MountainSystem> Get()
        {
            return _dbContext.MountainSystem;
        }

        [HttpPost]
        public IHttpActionResult Post(MountainSystem mountainSystem)
        {
            var ids = _dbContext.MountainSystem.Select(x => x.Id);

            mountainSystem.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
            _dbContext.MountainSystem.Add(mountainSystem);

            _dbContext.SaveChanges();
            return Ok(mountainSystem);
        }

        [HttpPost]
        public IHttpActionResult Post(IEnumerable<MountainSystem> mountainSystems)
        {
            var ids = _dbContext.MountainSystem.Select(x => x.Id);
            
            foreach (var mountainSystem in mountainSystems)
            {
                mountainSystem.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
                _dbContext.MountainSystem.Add(mountainSystem);
            }

            _dbContext.SaveChanges();
            return Ok(mountainSystems);
        }

    }
}
