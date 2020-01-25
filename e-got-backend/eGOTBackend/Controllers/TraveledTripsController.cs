﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
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
        public virtual TripViewModel Get()
        {
            return null;
        }
    }
}
