using System.Collections.Generic;
using System.Web.Http;
using eGOTBackend.Repostiories;
using eGOTBackend.Models;
using System.Web.Http.Cors;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LocationsController : ApiController
    {
        private readonly LocationsRepository _locationsRepository = new LocationsRepository();

        [HttpGet]
        [ActionName("getAll")]
        public List<Location> GetAll()
        {
            return _locationsRepository.GetAll();
        }
    }
}
