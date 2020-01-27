using System.Collections.Generic;
using System.Web.Http;
using eGOTBackend.Repostiories;
using eGOTBackend.Models;
using System.Web.Http.Cors;

namespace eGOTBackend.Controllers
{
    /// <summary>
    /// Klasa kontrolera punktów geograficznych obsługująca zapytania HTTP
    /// i łącząca się z repozytorium punktów geograficznych.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LocationsController : ApiController
    {
        private readonly LocationsRepository _locationsRepository = new LocationsRepository();

        /// <summary>
        /// Metoda obsługująca zapytanie GET dla api/locations/getAll.
        /// Pobiera z repozytorium punktów geograficznych wszystkie punkty geograficzne.
        /// </summary>
        /// <returns>Lista punktów geograficznych reprezentowanych przez klasę Location</returns>
        [HttpGet]
        [ActionName("getAll")]
        public List<Location> GetAll()
        {
            return _locationsRepository.GetAll();
        }
    }
}
