using System.Web.Http.Cors;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using eGOTBackend.Models;
using Newtonsoft.Json;

namespace eGOTBackend.Controllers
{
    [RoutePrefix("sections")]
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class SectionController : ApiController
    {
        [HttpGet]
        public IEnumerable<Section> Get()
        {
            using (var dbContext = new eGOTContext())
            {
                return dbContext.Section;
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Section section)
        {
            using (var dbContex = new eGOTContext())
            {
                var ids = dbContex.Section.Select(x => x.Id);
                section.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
                dbContex.Section.Add(section);
                dbContex.SaveChanges();

                return Ok(section);
            }
        }

        //[HttpPut]
        //public IHttpActionResult Put(Section section)
        //{
        //    var found = sectionList.Find(x => x.Id == section.Id);

        //    if (found == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(found);
        //}

        //[HttpDelete]
        //public IHttpActionResult Delete(int id)
        //{
        //    var indexToDelete = sectionList.FindIndex(t => t.Id == id);

        //    if (indexToDelete == -1)
        //    {
        //        return NotFound();
        //    }

        //    sectionList.RemoveAt(indexToDelete);
        //    return Ok();
        //}
    }
}
