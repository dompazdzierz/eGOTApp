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
    }
}
