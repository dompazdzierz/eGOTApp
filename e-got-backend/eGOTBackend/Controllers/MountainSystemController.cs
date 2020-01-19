using System.Web.Http.Cors;
using System.Web.Http;
using System.Collections.Generic;
using eGOTBackend.Models;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class MountainSystemController: BaseCrudController<MountainSystem>
    {
      
    }
}
