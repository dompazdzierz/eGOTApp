using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGOTBackend.Models
{
    /// <summary>
    /// Klasa nadrzędna dla wszystkich encji wykorzystywanych w modelu.
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
