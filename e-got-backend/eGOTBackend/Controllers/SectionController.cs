using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class SectionController : ApiController
    {
        public struct ApiSection
        {
            public int id { get; set; }
            public string start_location { get; set; }
            public string end_location { get; set; }
            public float length { get; set; }
            public float elevation_gain { get; set; }
            public int score { get; set; }
        }

        protected readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpGet]
        [ActionName("getAll")]
        public virtual IEnumerable<ApiSection> Get(string mountain_range)
        {
            int mountain_range_id = _dbContext.Set<MountainRange>().Where(x => x.Name == mountain_range).Select(x => x.Id).FirstOrDefault();

            IEnumerable<Section> entities = _dbContext.Set<Section>().Where(x => x.MountainRange == mountain_range_id);
            IEnumerable<ApiSection> api_entities = new List<ApiSection>();

            foreach (Section entity in entities)
            {
                api_entities = api_entities.Append(new ApiSection
                {
                    id = entity.Id,
                    start_location = _dbContext.Location.Where(x => x.Id == entity.StartLocation).Select(x => x.Name).FirstOrDefault(),
                    end_location = _dbContext.Location.Where(x => x.Id == entity.EndLocation).Select(x => x.Name).FirstOrDefault(),
                    length = entity.Length,
                    elevation_gain = entity.ElevationGain,
                    score = entity.Score
                });
            }

            return api_entities;
        }
    }
}
