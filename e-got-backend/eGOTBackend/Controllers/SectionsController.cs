using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using eGOTBackend.Repostiories;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class SectionsController : BaseCrudController<Section>
    {
        private readonly SectionsRepository _sectionsRangeRepository = new SectionsRepository();

        [HttpGet]
        [ActionName("getAll")]
        public virtual IEnumerable<SectionViewModel> GetAll(int mountainRangeId, bool status)
        {
            return _sectionsRangeRepository.GetAll(mountainRangeId, status);
        }

        [HttpGet]
        [ActionName("get")]
        public virtual Section Get(int id)
        {
            return _sectionsRangeRepository.Get(id);
        }

        [HttpPost]
        [ActionName("set")]
        public virtual IHttpActionResult Set(int id, int startLocationId, int endLocationId,
            float length, float elevationGain, int score, int mountainRangeId)
        {
            _dbContext.Section.Update(new Section
            {
                Id = id,
                StartLocationId = startLocationId,
                EndLocationId = endLocationId,
                Length = length,
                ElevationGain = elevationGain,
                Score = score,
                Status = true,
                MountainRangeId = mountainRangeId
            });
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
