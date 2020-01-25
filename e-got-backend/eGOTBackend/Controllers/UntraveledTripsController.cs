using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using eGOTBackend.Repostiories;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UntraveledTripsController : BaseCrudController<TripViewModel>
    {
        private readonly UntraveledTripsRepository _untraveledTripsRepository = new UntraveledTripsRepository();

        [HttpGet]
        [ActionName("getTourist")]
        public virtual IEnumerable<TripViewModel> GetTourist(int id)
        {
            return _untraveledTripsRepository.GetTourist(id);
        }

        [HttpGet]
        [ActionName("get")]
        public virtual TripViewModel Get(int id)
        {
            return _untraveledTripsRepository.Get(id);
        }

        [HttpDelete]
        [ActionName("removeElement")]
        public virtual IHttpActionResult RemoveElement(int id)
        {
            var proofsToDelete = _dbContext.PhotoProof.Where(x => x.IdTrip == id);

            _dbContext.PhotoProof.RemoveRange(proofsToDelete);
            _dbContext.SaveChanges();

            _dbContext.Trip.Remove(new Trip
            {
                Id = id
            });
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [ActionName("set")]
        public virtual IHttpActionResult Set(int id, string title, string startDate, string endDate)
        {
            Trip trip = new Trip
            {
                Id = id,
                Title = title,
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse(endDate)
            };

            _dbContext.Trip.Attach(trip);
            _dbContext.Entry(trip).Property(x => x.Title).IsModified = true;
            _dbContext.Entry(trip).Property(x => x.StartDate).IsModified = true;
            _dbContext.Entry(trip).Property(x => x.EndDate).IsModified = true;
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
