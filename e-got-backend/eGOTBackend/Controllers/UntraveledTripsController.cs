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
    public class UntraveledTripsController : ApiController
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
            _untraveledTripsRepository.RemoveElement(id);

            return Ok();
        }

        [HttpPost]
        [ActionName("set")]
        public virtual IHttpActionResult Set(int id, string title, string startDate, string endDate)
        {
            _untraveledTripsRepository.Set(id, title, startDate, endDate);

            return Ok();
        }
    }
}
