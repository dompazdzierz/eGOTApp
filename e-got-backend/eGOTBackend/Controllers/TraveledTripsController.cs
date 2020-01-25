using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using eGOTBackend.Repostiories;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TraveledTripsController : BaseCrudController<TripViewModel>
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
            Trip trip = new Trip
            {
                Id = id,
                Status = 0,
            };

            _dbContext.Trip.Attach(trip);
            _dbContext.Entry(trip).Property(x => x.Status).IsModified = true;
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [ActionName("reject")]
        public virtual IHttpActionResult Reject(int id)
        {
            Trip trip = new Trip
            {
                Id = id,
                Status = -1,
            };

            _dbContext.Trip.Attach(trip);
            _dbContext.Entry(trip).Property(x => x.Status).IsModified = true;
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
