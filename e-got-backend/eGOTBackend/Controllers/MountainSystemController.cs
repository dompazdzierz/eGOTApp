﻿using System.Web.Http.Cors;
using eGOTBackend.Models;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class MountainSystemController: BaseCrudController<MountainSystem>
    {
      
    }
}
