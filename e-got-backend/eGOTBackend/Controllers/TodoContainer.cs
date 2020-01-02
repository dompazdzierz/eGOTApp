using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    public class TodoContainer
    {
        public List<Todo> Todos { get; } = new List<Todo>();

        public TodoContainer()
        {
        }

    }
}