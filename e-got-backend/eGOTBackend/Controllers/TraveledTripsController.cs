using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using eGOTBackend.Repostiories;

namespace eGOTBackend.Controllers
{
    /// <summary>
    /// Klasa kontrolera przebytych wycieczek obsługująca zapytania HTTP i łącząca się
    /// z repozytorium przebytych wycieczek.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TraveledTripsController : ApiController
    {
        private readonly TraveledTripsRepository _traveledTripsRepository = new TraveledTripsRepository();

        /// <summary>
        /// Metoda obsługująca zapytanie GET dla api/traveledtrips/getAll.
        /// Pobiera z repozytorium przebytych wycieczek wszystkie wycieczki.
        /// </summary>
        /// <returns>Lista wycieczek reprezentowanych przez klasę TripViewModel</returns>
        [HttpGet]
        [ActionName("getAll")]
        public virtual IEnumerable<TripViewModel> GetAll()
        {
            return _traveledTripsRepository.GetAll();
        }

        /// <summary>
        /// Metoda obsługująca zapytanie GET dla api/traveledtrips/get.
        /// Pobiera z repozytorium przebytych wycieczek wycieczkę o konkretnym identyfikatorze
        /// przekazanym w parametrze metody.
        /// </summary>
        /// <param name="id">Identyfikator wycieczki</param>
        /// <returns>Wycieczka reprezentowana przez klasę TripViewModel</returns>
        [HttpGet]
        [ActionName("get")]
        public virtual TripViewModel Get(int id)
        {
            return _traveledTripsRepository.Get(id);
        }

        /// <summary>
        /// Metoda obsługująca zapytanie POST dla api/traveledtrips/accept.
        /// Modyfikuje w repozytorium przebytych wycieczek status wycieczki o konkretnym
        /// identyfikatorze na zaakceptowaną.
        /// </summary>
        /// <param name="id">Identyfikator wycieczki</param>
        /// <returns>Kod HTTP</returns>
        [HttpPost]
        [ActionName("accept")]
        public virtual IHttpActionResult Accept(int id)
        {
            _traveledTripsRepository.Accept(id);

            return Ok();
        }

        /// <summary>
        /// Metoda obsługująca zapytanie POST dla api/traveledtrips/accept.
        /// Modyfikuje w repozytorium przebytych wycieczek status wycieczki o konkretnym
        /// identyfikatorze na odrzuconą.
        /// </summary>
        /// <param name="id">Identyfikator wycieczki</param>
        /// <returns>Kod HTTP</returns>
        [HttpPost]
        [ActionName("reject")]
        public virtual IHttpActionResult Reject(int id)
        {
            _traveledTripsRepository.Reject(id);

            return Ok();
        }
    }
}
