using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using eGOTBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public abstract class BaseCrudController<TEntity> : ApiController
        where TEntity : class, IEntity, new()
    {
        protected readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpGet]
        [ActionName("getAll")]
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        [HttpPost]
        [ActionName("addElement")]
        public virtual IHttpActionResult Post(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();

            return Ok(entity);
        }

        [HttpPost]
        [ActionName("addElements")]
        public virtual IHttpActionResult Post(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            _dbContext.SaveChanges();

            return Ok(entities);
        }

    }
}