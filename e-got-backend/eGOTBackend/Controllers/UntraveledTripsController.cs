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
        public virtual IEnumerable<TripViewModel> Get(int id)
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
    }
}
