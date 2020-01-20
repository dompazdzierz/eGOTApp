using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using eGOTBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class MountainSystemController: BaseCrudController<MountainSystem>
    {

    }
}
