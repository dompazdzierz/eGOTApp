// Dominik Paździerz 242514

using System.Web.Http.Cors;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [RoutePrefix("section")]
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class SectionController : ApiController
    {
        static List<Section> sectionList = new List<Section>();

        [HttpGet]
        public IEnumerable<Section> Get()
        {
            return sectionList;
        }

        [HttpPost]
        public Section Post(Section section)
        {
            var ids = sectionList.Select(x => x.Id);
            section.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
            sectionList.Add(section);
            return section;
        }

        [HttpPut]
        public IHttpActionResult Put(Section section)
        {
            var found = sectionList.Find(x => x.Id == section.Id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var indexToDelete = sectionList.FindIndex(t => t.Id == id);

            if (indexToDelete == -1)
            {
                return NotFound();
            }

            sectionList.RemoveAt(indexToDelete);
            return Ok();
        }
    }
}
