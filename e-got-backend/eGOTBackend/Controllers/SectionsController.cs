using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using eGOTBackend.Repostiories;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class SectionsController : ApiController
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
            _sectionsRangeRepository.Set(id, startLocationId, endLocationId, length,
                elevationGain, score, mountainRangeId);

            return Ok();
        }

        [HttpPost]
        [ActionName("addElement")]
        public virtual IHttpActionResult AddElement(int startLocationId, int endLocationId,
            float length, float elevationGain, int score, int mountainRangeId, bool status = true)
        {
            _sectionsRangeRepository.AddElement(startLocationId, endLocationId, length,
                elevationGain, score, mountainRangeId, status);

            return Ok();
        }

        [HttpDelete]
        [ActionName("removeElement")]
        public virtual IHttpActionResult RemoveElement(int id)
        {
            _sectionsRangeRepository.RemoveElement(id);

            return Ok();
        }

        [HttpPost]
        [ActionName("accept")]
        public virtual IHttpActionResult Accept(int id)
        {
            _sectionsRangeRepository.Accept(id);

            return Ok();
        }
    }
}
