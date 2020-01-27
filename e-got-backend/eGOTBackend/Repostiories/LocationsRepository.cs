using System.Collections.Generic;
using System.Linq;
using eGOTBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace eGOTBackend.Repostiories
{
    /// <summary>
    /// Klasa repozytorium punktów geograficznych służąca do łączenia się z bazą danych.
    /// </summary>
    public class LocationsRepository : BaseRepository
    {
        /// <summary>
        /// Metoda obsługująca pobieranie wszystkich punktów geograficznych z bazy danych.
        /// </summary>
        /// <returns>Lista punktów geograficznych reprezentowanych przez klasę Location</returns>
        public List<Location> GetAll()
        {
            var sections = dbContext.Location.ToList();

            if (sections == null)
            {
                return null;
            }

            return sections;
        }
    }
}