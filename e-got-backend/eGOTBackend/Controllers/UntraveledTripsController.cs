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
    /// <summary>
    /// Klasa kontrolera nieprzebytych wycieczek obsługująca zapytania HTTP i łącząca się
    /// z repozytorium nieprzebytych wycieczek.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UntraveledTripsController : ApiController
    {
        private readonly UntraveledTripsRepository _untraveledTripsRepository = new UntraveledTripsRepository();

        /// <summary>
        /// Metoda obsługująca zapytanie GET dla api/untraveledtrips/getTourist.
        /// Pobiera z repozytorium nieprzebytych wycieczek wszystkie wycieczki należące
        /// do tursysty o konkretnym identyfikatorze przekazanym w parametrze.
        /// </summary>
        /// <param name="id">Identyfikator turysty</param>
        /// <returns>Lista nieprzebytych wycieczek reprezentowanych przez klasę TripViewModel></returns>
        [HttpGet]
        [ActionName("getTourist")]
        public virtual IEnumerable<TripViewModel> GetTourist(int id)
        {
            return _untraveledTripsRepository.GetTourist(id);
        }

        /// <summary>
        /// Metoda obsługująca zapytanie GET dla api/traveledtrips/get.
        /// Pobiera z repozytorium nieprzebytych wycieczek wycieczkę o konkretnym
        /// identyfikatorze przekazanym w parametrze.
        /// </summary>
        /// <param name="id">Identyfikator wycieczki</param>
        /// <returns>Wycieczka reprezentowana przez klasę TripViewModel</returns>
        [HttpGet]
        [ActionName("get")]
        public virtual TripViewModel Get(int id)
        {
            return _untraveledTripsRepository.Get(id);
        }

        /// <summary>
        /// Metoda obsługująca zapytanie DELETE dla api/traveledtrips/removeElement.
        /// Usuwa z repozytorium nieprzebytych wycieczek wycieczkę o konkretnym identyfikatorze
        /// przezkazanym w parametrze. W przypadku poprawnego zaakceptowania odcinka,
        /// zwraca odpowiedź 200 OK.
        /// </summary>
        /// <param name="id">Identyfikator wycieczki</param>
        /// <returns>Kod HTTP</returns>
        [HttpDelete]
        [ActionName("removeElement")]
        public virtual IHttpActionResult RemoveElement(int id)
        {
            _untraveledTripsRepository.RemoveElement(id);

            return Ok();
        }

        /// <summary>
        /// Metoda obsługująca zapytanie POST dla api/traveledtrips/set.
        /// Modyfikuje w repozytorium nieprzebytych wycieczek wycieczkę o konkretnym
        /// identyfikatorze o dane przekazane w parametrach metody. W przypadku poprawnego
        /// zmodyfikowania odcinka w bazie, zwraca odpowiedź 200 OK.
        /// </summary>
        /// <param name="id">Identyfikator modyfikowanej wycieczki</param>
        /// <param name="title">Tytuł wycieczki</param>
        /// <param name="startDate">Data rozpoczęcia wycieczki</param>
        /// <param name="endDate">Data zakończenia wycieczki</param>
        /// <returns>Kod HTTP</returns>
        [HttpPost]
        [ActionName("set")]
        public virtual IHttpActionResult Set(int id, string title, string startDate, string endDate)
        {
            _untraveledTripsRepository.Set(id, title, startDate, endDate);

            return Ok();
        }
    }
}
