using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
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

        [HttpGet]
        [ActionName("get")]
        public virtual TripViewModel Get(int id)
        {
            return _traveledTripsRepository.Get(id);
        }

        [HttpPost]
        [ActionName("accept")]
        public virtual IHttpActionResult Accept(int id)
        {
            _traveledTripsRepository.Accept(id);

            return Ok();
        }

        [HttpPost]
        [ActionName("reject")]
        public virtual IHttpActionResult Reject(int id)
        {
            _traveledTripsRepository.Reject(id);

            return Ok();
        }
    }
}
