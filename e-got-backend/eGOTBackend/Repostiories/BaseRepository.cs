using eGOTBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGOTBackend.Repostiories
{
    public class BaseRepository
    {
        protected ApplicationDbContext dbContext = new ApplicationDbContext();
    }
}