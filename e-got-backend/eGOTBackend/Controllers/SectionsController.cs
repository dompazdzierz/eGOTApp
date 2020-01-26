using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using eGOTBackend.Repostiories;

namespace eGOTBackend.Controllers
{
    /// <summary>
    /// Klasa kontrolera odcinków obsługująca zapytania HTTP i łącząca się z repozytorium odcinków.
    /// </summary>
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class SectionsController : ApiController
    {
        private readonly SectionsRepository _sectionsRangeRepository = new SectionsRepository();

        /// <summary>
        /// Metoda obsługująca zapytanie GET dla api/sections/getAll.
        /// Pobiera z repozytorium odcinków wszystkie odcinki należące do przekazanej
        /// grupy górskiej, oraz jednocześnie takie, których status zgadza się z
        /// przekazanym w parametrze.
        /// </summary>
        /// <param name="mountainRangeId">Idektyfikator grupy górskiej</param>
        /// <param name="status">Status odcinka</param>
        /// <returns>Lista odcinków reprezentowanych przez klasę SectionViewModel</returns>
        [HttpGet]
        [ActionName("getAll")]
        public virtual IEnumerable<SectionViewModel> GetAll(int mountainRangeId, bool status)
        {
            return _sectionsRangeRepository.GetAll(mountainRangeId, status);
        }

        /// <summary>
        /// Metoda obsługująca zapytanie GET dla api/sections/get.
        /// Pobiera z repozytorium odcinków dane odcinka o konkretnym identyfikatorze.
        /// </summary>
        /// <param name="id">Identyfikator odcinka</param>
        /// <returns>Odcinek reprezentowany przez klasę Section</returns>
        [HttpGet]
        [ActionName("get")]
        public virtual Section Get(int id)
        {
            return _sectionsRangeRepository.Get(id);
        }

        /// <summary>
        /// Metoda obsługująca zapytanie POST dla api/sections/set.
        /// Modyfikuje w repozytorium odcinków odcinek o konkretnym identyfikatorze o dane
        /// przekazane w parametrach metody. W przypadku poprawnego zmodyfikowania odcinka
        /// w bazie, zwraca odpowiedź 200 OK.
        /// </summary>
        /// <param name="id">Identyfikator modyfikowanego odcinka</param>
        /// <param name="startLocationId">Identyfikator punktu początkowego</param>
        /// <param name="endLocationId">Identyfikator punktu końcowego</param>
        /// <param name="length">Długość odcinka</param>
        /// <param name="elevationGain">Przewyższenie odcinka</param>
        /// <param name="score">Punktacja odcinka</param>
        /// <param name="mountainRangeId">Identyfikator grupy górskiej do której należy odcinek</param>
        /// <returns>Kod HTTP</returns>
        [HttpPost]
        [ActionName("set")]
        public virtual IHttpActionResult Set(int id, int startLocationId, int endLocationId,
            float length, float elevationGain, int score, int mountainRangeId)
        {
            _sectionsRangeRepository.Set(id, startLocationId, endLocationId, length,
                elevationGain, score, mountainRangeId);

            return Ok();
        }

        /// <summary>
        /// Metoda obsługująca zapytanie POST dla api/sections/addElement.
        /// Dodaje do repozytorium odcinków odcinek z danymi przekazanymi w parametrze
        /// metody. W przypadku poprawnego dodania odcinka do bazy, zwraca odpowiedź 200 OK.
        /// </summary>
        /// <param name="startLocationId">Identyfikator punktu początkowego</param>
        /// <param name="endLocationId">Identyfikator punktu końcowego</param>
        /// <param name="length">Długość odcinka</param>
        /// <param name="elevationGain">Przewyższenie odcinka</param>
        /// <param name="score">Punktacja odcinka</param>
        /// <param name="mountainRangeId">Identyfikator grupy górskiej do której należy odcinek</param>
        /// <param name="status">Status odcinka, domyślnie niezaakceptowany</param>
        /// <returns>Kod HTTP</returns>
        [HttpPost]
        [ActionName("addElement")]
        public virtual IHttpActionResult AddElement(int startLocationId, int endLocationId,
            float length, float elevationGain, int score, int mountainRangeId, bool status = true)
        {
            _sectionsRangeRepository.AddElement(startLocationId, endLocationId, length,
                elevationGain, score, mountainRangeId, status);

            return Ok();
        }

        /// <summary>
        /// Metoda obsługująca zapytanie DELETE dla api/sections/removeElement.
        /// Usuwa z repozytorium odcinków odcinek z identyfikatorem przekazanym w parametrze.
        /// W przypadku poprawnego usunięcia odcinka z bazy, zwraca odpowiedź 200 OK.
        /// </summary>
        /// <param name="id">Identyfikator usuwanego odcinka</param>
        /// <returns>Kod HTTP</returns>
        [HttpDelete]
        [ActionName("removeElement")]
        public virtual IHttpActionResult RemoveElement(int id)
        {
            _sectionsRangeRepository.RemoveElement(id);

            return Ok();
        }

        /// <summary>
        /// Metoda obsługująca zapytanie POST dla api/sections/accept.
        /// Zmienia w repozytorium odcinków status odcinka o identyfikatorze przekazanym
        /// w parametrze na zaakceptowany. W przypadku poprawnego zaakceptowania odcinka,
        /// zwraca odpowiedź 200 OK.
        /// </summary>
        /// <param name="id">Identyfikator akceptowanego odcinka</param>
        /// <returns>Kod HTTP</returns>
        [HttpPost]
        [ActionName("accept")]
        public virtual IHttpActionResult Accept(int id)
        {
            _sectionsRangeRepository.Accept(id);

            return Ok();
        }
    }
}
