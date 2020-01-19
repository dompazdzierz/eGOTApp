using System.Web.Http.Cors;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using eGOTBackend.Models;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class SectionController: ApiController
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<Section> Get()
        {
            return _dbContext.Section;
        }

        [HttpPost]
        public IHttpActionResult Post(Section section)
        {
            var ids = _dbContext.Section.Select(x => x.Id);

            section.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
            _dbContext.Section.Add(section);

            _dbContext.SaveChanges();
            return Ok(section);
        }

        [HttpPost]
        public IHttpActionResult Post(IEnumerable<Section> sections)
        {
            var ids = _dbContext.Section.Select(x => x.Id);
            
            foreach (var section in sections)
            {
                section.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
                _dbContext.Section.Add(section);
            }

            _dbContext.SaveChanges();
            return Ok(sections);
        }

    }
}
