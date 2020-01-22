using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using eGOTBackend.Repostiories;
using Microsoft.EntityFrameworkCore;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MountainRangesController : ApiController
    {
        private readonly MountainRangesRepostiory _mountainsRangeRepository = new MountainRangesRepostiory();

        [HttpGet]
        [ActionName("getAll")]
        public List<MountainRangeViewModel> GetAll()
        {
            return _mountainsRangeRepository.GetAll();
        }

        [HttpGet]
        [ActionName("get")]
        public MountainRangeViewModel Get(int id)
        {
            return _mountainsRangeRepository.Get(id);
        }

    }
}
