using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using eGOTBackend.Models;

namespace eGOTBackend.Controllers
{
    public abstract class BaseCrudController<TEntity> : ApiController
        where TEntity : class, IEntity, new()
    {
        protected readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpGet]
        public virtual IEnumerable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>();
        }

        [HttpPost]
        public virtual IHttpActionResult Post(TEntity entity)
        {
            var ids = _dbContext.Set<TEntity>().Select(x => x.Id);

            entity.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
            _dbContext.Set<TEntity>().Add(entity);

            _dbContext.SaveChanges();
            return Ok(entity);
        }

        [HttpPost]
        public virtual IHttpActionResult Post(IEnumerable<TEntity> entities)
        {
            var ids = _dbContext.Set<TEntity>().Select(x => x.Id);

            foreach (var entity in entities)
            {
                entity.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
                _dbContext.Set<TEntity>().Add(entity);
            }

            _dbContext.SaveChanges();
            return Ok(entities);
        }

    }
}