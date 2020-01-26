using eGOTBackend.Models.ViewModels;
using eGOTBackend.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eGOTBackend.Repostiories
{
    /// <summary>
    /// Klasa repozytorium odcinków służąca do łączenia się z bazą danych.
    /// </summary>
    public class SectionsRepository : BaseRepository
    {
        /// <summary>
        /// Metoda obsługująca pobieranie z bazy danych odcinków wszystkie odcinki
        /// należące do przekazanej grupy górskiej, oraz jednocześnie takie, których status
        /// zgadza się z przekazanym w parametrze.
        /// </summary>
        /// <param name="mountainRangeId">Idektyfikator grupy górskiej</param>
        /// <param name="status">Status odcinka</param>
        /// <returns>Lista odcinków reprezentowanych przez klasę SectionViewModel</returns>
        public List<SectionViewModel> GetAll(int mountainRangeId, bool status)
        {
            var sections = new List<Section>();
            sections = dbContext.Section
                .Where(x => x.MountainRangeId == mountainRangeId && x.Status == status)
                .Include(x => x.EndLocation).Include(x => x.StartLocation).Include(x => x.MountainRange)
                .ToList();

            if (sections == null)
            {
                return null;
            }

            List<SectionViewModel> sectionViewModels = new List<SectionViewModel>();
            foreach (var x in sections)
            {
                var sectionViewModel = new SectionViewModel()
                {
                    Id = x.Id,
                    StartLocation = x.StartLocation.Name,
                    EndLocation = x.EndLocation.Name,
                    Length = x.Length,
                    ElevationGain = x.ElevationGain,
                    Score = x.Score,
                    Status = x.Status,
                    MountainRange = x.MountainRange.Name
                };
                sectionViewModels.Add(sectionViewModel);
            }

            return sectionViewModels;           
        }

        /// <summary>
        /// Metoda obsługująca pobieranie z bazy danych dane odcinka o konkretnym identyfikatorze.
        /// </summary>
        /// <param name="id">Identyfikator odcinka</param>
        /// <returns>Odcinek reprezentowany przez klasę Section</returns>
        public Section Get(int id)
        {
            var section = dbContext.Section
                .Where(x => x.Id == id)
                .Single();

            if (section == null)
            {
                return null;
            }

            return section;
        }

        /// <summary>
        /// Metoda obsługująca modyfikowanie w bazie danych odcinka o konkretnym identyfikatorze
        /// o dane przekazane w parametrach metody.
        /// </summary>
        /// <param name="id">Identyfikator modyfikowanego odcinka</param>
        /// <param name="startLocationId">Identyfikator punktu początkowego</param>
        /// <param name="endLocationId">Identyfikator punktu końcowego</param>
        /// <param name="length">Długość odcinka</param>
        /// <param name="elevationGain">Przewyższenie odcinka</param>
        /// <param name="score">Punktacja odcinka</param>
        /// <param name="mountainRangeId">Identyfikator grupy górskiej do której należy odcinek</param>
        public void Set(int id, int startLocationId, int endLocationId,
            float length, float elevationGain, int score, int mountainRangeId)
        {
            dbContext.Section.Update(new Section
            {
                Id = id,
                StartLocationId = startLocationId,
                EndLocationId = endLocationId,
                Length = length,
                ElevationGain = elevationGain,
                Score = score,
                Status = true,
                MountainRangeId = mountainRangeId
            });
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Metoda obsługująca dodawanie do bazy danych odcinka z danymi przekazanymi
        /// w parametrze metody.
        /// </summary>
        /// <param name="startLocationId">Identyfikator punktu początkowego</param>
        /// <param name="endLocationId">Identyfikator punktu końcowego</param>
        /// <param name="length">Długość odcinka</param>
        /// <param name="elevationGain">Przewyższenie odcinka</param>
        /// <param name="score">Punktacja odcinka</param>
        /// <param name="mountainRangeId">Identyfikator grupy górskiej do której należy odcinek</param>
        /// <param name="status">Status odcinka, domyślnie niezaakceptowany</param>
        public void AddElement(int startLocationId, int endLocationId,
            float length, float elevationGain, int score, int mountainRangeId, bool status = true)
        {
            dbContext.Section.Add(new Section
            {
                StartLocationId = startLocationId,
                EndLocationId = endLocationId,
                Length = length,
                ElevationGain = elevationGain,
                Score = score,
                Status = status,
                MountainRangeId = mountainRangeId
            });
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Metoda obsługująca usuwanie z bazy danych odcinka z identyfikatorem
        /// przekazanym w parametrze.
        /// </summary>
        /// <param name="id">Identyfikator usuwanego odcinka</param>
        public void RemoveElement(int id)
        {
            dbContext.Section.Remove(new Section
            {
                Id = id
            });
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Metoda obsługująca zmienianie w bazie danych statusu odcinka o identyfikatorze
        /// przekazanym w parametrze na zaakceptowany.
        /// </summary>
        /// <param name="id">Identyfikator akceptowanego odcinka</param>
        public void Accept(int id)
        {
            Section section = new Section
            {
                Id = id,
                Status = true,
            };

            dbContext.Section.Attach(section);
            dbContext.Entry(section).Property(x => x.Status).IsModified = true;
            dbContext.SaveChanges();
        }
    }
}