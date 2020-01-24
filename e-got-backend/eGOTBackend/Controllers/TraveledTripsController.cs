using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models.ViewModels;
using eGOTBackend.Repostiories;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TraveledTripsController : ApiController
    {
        private readonly TraveledTripsRepository _traveledTripsRepository = new TraveledTripsRepository();

        [HttpGet]
        [ActionName("getAll")]
        public virtual IEnumerable<TripViewModel> GetAll()
        {
            return _traveledTripsRepository.GetAll();
        }
    }
}
