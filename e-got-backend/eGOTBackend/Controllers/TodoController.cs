// Dominik Paździerz 242514

using System.Web.Http.Cors;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{
    [RoutePrefix("todo")]
    [EnableCors(origins: "*", headers:"*" , methods:"*")]
    public class TodoController : ApiController
    {
        static TodoContainer _todoContainer = new TodoContainer();

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todoContainer.Todos;
        }

        [HttpPost]
        public Todo Post(Todo todo)
        {
            var ids = _todoContainer.Todos.Select(x => x.Id);
            todo.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
            _todoContainer.Todos.Add(todo);
            return todo;
        }

        [HttpPut]
        public IHttpActionResult Put(Todo todo)
        {
            var found = _todoContainer.Todos.Find(x => x.Id == todo.Id);

            if (found == null)
            {
                return NotFound();
            }

            found.Done = todo.Done;
            return Ok(found);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var indexToDelete = _todoContainer.Todos.FindIndex(t => t.Id == id);

            if (indexToDelete == -1)
            {
                return NotFound();
            }

            _todoContainer.Todos.RemoveAt(indexToDelete);
            return Ok();
        }
    }
}
