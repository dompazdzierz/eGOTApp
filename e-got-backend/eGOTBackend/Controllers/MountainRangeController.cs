using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MountainRangeController : ApiController
    {
        public struct ApiMountainRange
        {
            public string name { get; set; }
            public string mountain_system { get; set; }
        }

        protected readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpGet]
        [ActionName("getAll")]
        public virtual IEnumerable<ApiMountainRange> Get()
        {
            IEnumerable<MountainRange> entities = _dbContext.Set<MountainRange>();
            IEnumerable<ApiMountainRange> api_entities = new List<ApiMountainRange>();

            foreach (MountainRange entity in entities)
            {
                api_entities = api_entities.Append(new ApiMountainRange
                {
                    name = entity.Name,
                    mountain_system = _dbContext.MountainSystem
                        .Where(x => x.Id == entity.MountainSystem)
                        .Select(x => x.Name)
                        .FirstOrDefault()
                });
            }

            return api_entities;
        }

        [HttpPost]
        [ActionName("addElement")]
        public virtual IHttpActionResult Post(ApiMountainRange api_entity)
        {
            MountainRange entity = new MountainRange
            {
                Id = 0,
                Name = api_entity.name,
                MountainSystem = _dbContext.MountainSystem
                    .Where(x => x.Name == api_entity.mountain_system)
                    .Select(x => x.Id)
                    .FirstOrDefault()
            };

            _dbContext.Set<MountainRange>().Add(entity);
            _dbContext.SaveChanges();

            return Ok(entity);
        }

        [HttpPost]
        [ActionName("addElements")]
        public virtual IHttpActionResult Post(IEnumerable<ApiMountainRange> api_entities)
        {
            IEnumerable<MountainRange> entities = new List<MountainRange>();

            foreach (ApiMountainRange api_entity in api_entities)
            {
                MountainRange entity = new MountainRange
                {
                    Id = 0,
                    Name = api_entity.name,
                    MountainSystem = _dbContext.MountainSystem
                        .Where(x => x.Name == api_entity.mountain_system)
                        .Select(x => x.Id)
                        .FirstOrDefault()
                };
                entities = entities.Append(entity);
            }

            _dbContext.Set<MountainRange>().AddRange(entities);
            _dbContext.SaveChanges();

            return Ok(entities);
        }
    }
}
