using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using eGOTBackend.Repostiories;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MountainSystemsController : ApiController
    {
        private MountainSystemsRepository _mountainSystemsRepository = new MountainSystemsRepository();

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable<MountainSystemViewModel> GetAll()
        {
            return _mountainSystemsRepository.GetAll();
        }

    }
}