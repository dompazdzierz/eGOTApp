using eGOTBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eGOTBackend.Repostiories
{
    /// <summary>
    /// Klasa repozytorium grup górskich służąca do łączenia się z bazą danych.
    /// </summary>
    public class MountainRangesRepostiory : BaseRepository
    {
        /// <summary>
        /// Metoda obsługująca pobieranie z bazy danych wszystkich grup górskich.
        /// </summary>
        /// <returns>Lista grup górskich reprezentowanych przez klasę MountainRangeViewModel</returns>
        public List<MountainRangeViewModel> GetAll()
        {
            List<MountainRange> mountainRanges = new List<MountainRange>();
            mountainRanges = dbContext.MountainRange.AsNoTracking()
                .Include(x => x.MountainSystem)
                .ToList();

            if (mountainRanges == null)
            {
                return null;
            }

            mountainRanges.Sort((a, b) => a.MountainSystem.Id.CompareTo(b.MountainSystem.Id));

            List<MountainRangeViewModel> mountainRangeViewModels = new List<MountainRangeViewModel>();
            foreach (var x in mountainRanges)
            {
                var mountainRangeViewModel = new MountainRangeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    MountainSystemName = x.MountainSystem.Name
                };
                mountainRangeViewModels.Add(mountainRangeViewModel);
            }

            return mountainRangeViewModels;               
        }

        /// <summary>
        /// Metoda obsługująca pobieranie z bazy danych grupę górską o konkretnym identyfikatorze
        /// przekazanym w parametrze.
        /// </summary>
        /// <param name="id">Identyfikator grupy górskiej</param>
        /// <returns>Grupa górska reprezentowana przez klasę MountainRangeViewModel</returns>
        public MountainRangeViewModel Get(int id)
        {
            var mountainRange = dbContext.MountainRange.AsNoTracking()
                .Include(x => x.MountainSystem)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (mountainRange == null)
            {
                return null;
            }

            var mountainRangeViewModel = new MountainRangeViewModel()
            {
                Id = mountainRange.Id,
                Name = mountainRange.Name,
                MountainSystemName = mountainRange.MountainSystem.Name
            };
                
            return mountainRangeViewModel;
        }
    }
}