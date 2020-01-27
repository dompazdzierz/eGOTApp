using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using eGOTBackend.Repostiories;
using Microsoft.EntityFrameworkCore;

namespace eGOTBackend.Controllers
{
    /// <summary>
    /// Klasa kontrolera grup górskich obsługująca zapytania HTTP i łącząca się
    /// z repozytorium grup górskich.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MountainRangesController : ApiController
    {
        private readonly MountainRangesRepostiory _mountainsRangeRepository = new MountainRangesRepostiory();

        /// <summary>
        /// Metoda obsługująca zapytanie GET dla api/mountainranges/getAll.
        /// Pobiera z repozytorium grup górskich wszystkie grupy górskie.
        /// </summary>
        /// <returns>Lista grup górskich reprezentowanych przez klasę MountainRangeViewModel</returns>
        [HttpGet]
        [ActionName("getAll")]
        public List<MountainRangeViewModel> GetAll()
        {
            return _mountainsRangeRepository.GetAll();
        }

        /// <summary>
        /// Metoda obsługująca zapytanie GET dla api/mountainranges/get.
        /// Pobiera z repozytorium grup górskich grupę górską o konkretnym identyfikatorze
        /// przekazanym w parametrze.
        /// </summary>
        /// <param name="id">Identyfikator grupy górskiej</param>
        /// <returns>Grupa górska reprezentowana przez klasę MountainRangeViewModel</returns>
        [HttpGet]
        [ActionName("get")]
        public MountainRangeViewModel Get(int id)
        {
            return _mountainsRangeRepository.Get(id);
        }

    }
}
