using System.Collections.Generic;
using System.Web.Http;
using eGOTBackend.Repostiories;
using eGOTBackend.Models;

namespace eGOTBackend.Controllers
{
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
