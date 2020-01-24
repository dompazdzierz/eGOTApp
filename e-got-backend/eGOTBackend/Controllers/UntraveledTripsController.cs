using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models.ViewModels;
using eGOTBackend.Repostiories;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UntraveledTripsController : ApiController
    {
        private readonly UntraveledTripsRepository _untraveledTripsRepository = new UntraveledTripsRepository();

        [HttpGet]
        [ActionName("get")]
        public virtual IEnumerable<TripViewModel> GetAll(int touristId)
        {
            return _untraveledTripsRepository.Get(touristId);
        }
    }
}
