using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGOTBackend.Repostiories
{
    /// <summary>
    /// Klasa repozytorium nieprzebytych wycieczek służąca do łączenia się z bazą danych.
    /// </summary>
    public class UntraveledTripsRepository : BaseRepository
    {
        /// <summary>
        /// Metoda obsługująca pobieranie z bazy danych wszystkich wycieczek należących
        /// do tursysty o konkretnym identyfikatorze przekazanym w parametrze.
        /// </summary>
        /// <param name="id">Identyfikator turysty</param>
        /// <returns>Lista nieprzebytych wycieczek reprezentowanych przez klasę TripViewModel></returns>
        public List<TripViewModel> GetTourist(int id)
        {
            // the touristId variable actually doesn't even matter
            int actualTouristId = dbContext.Tourist
                .Include(x => x.IdUserNavigation)
                .Where(x => x.IdUserNavigation.Email == "jankowalski@gmail.com")
                .Select(x => x.IdUser)
                .FirstOrDefault();

            var trips = dbContext.Trip
                .Where(x => x.Status == 0 && x.IdTourist == actualTouristId)
                .ToList();

            if (trips == null)
            {
                return null;
            }

            List<TripViewModel> tripViewModels = new List<TripViewModel>();
            foreach (var x in trips)
            {
                var tripViewModel = new TripViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    StartDate = x.StartDate.ToString("dd.MM.yyyy"),
                    EndDate = x.EndDate.ToString("dd.MM.yyyy"),
                    Score = x.Score,
                    Length = x.Length,
                    ElevationGain = x.ElevationGain
                };
                tripViewModels.Add(tripViewModel);
            }

            return tripViewModels;
        }

        /// <summary>
        /// Metoda obsługująca pobieranie z bazy danych wycieczki o konkretnym
        /// identyfikatorze przekazanym w parametrze.
        /// </summary>
        /// <param name="id">Identyfikator wycieczki</param>
        /// <returns>Wycieczka reprezentowana przez klasę TripViewModel</returns>
        public TripViewModel Get(int id)
        {
            var trip = dbContext.Trip
                .Where(x => x.Id == id)
                .Single();

            if (trip == null)
            {
                return null;
            }

            return new TripViewModel
            {
                Id = trip.Id,
                Title = trip.Title,
                StartDate = trip.StartDate.ToString("dd.MM.yyyy"),
                EndDate = trip.EndDate.ToString("dd.MM.yyyy"),
                Score = trip.Score,
                Length = trip.Length,
                ElevationGain = trip.ElevationGain
            };
        }

        /// <summary>
        /// Metoda obsługująca usuwanie z bazy danych wycieczki o konkretnym identyfikatorze
        /// przezkazanym w parametrze.
        /// </summary>
        /// <param name="id">Identyfikator wycieczki</param>
        /// <returns>Kod HTTP</returns>
        public void RemoveElement(int id)
        {
            var proofsToDelete = dbContext.PhotoProof.Where(x => x.IdTrip == id);

            dbContext.PhotoProof.RemoveRange(proofsToDelete);
            dbContext.SaveChanges();

            dbContext.Trip.Remove(new Trip
            {
                Id = id
            });
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Metoda obsługująca modyfikowanie w bazie danych wycieczki o konkretnym
        /// identyfikatorze o dane przekazane w parametrach metody.
        /// </summary>
        /// <param name="id">Identyfikator modyfikowanej wycieczki</param>
        /// <param name="title">Tytuł wycieczki</param>
        /// <param name="startDate">Data rozpoczęcia wycieczki</param>
        /// <param name="endDate">Data zakończenia wycieczki</param>
        public void Set(int id, string title, string startDate, string endDate)
        {
            Trip trip = new Trip
            {
                Id = id,
                Title = title,
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse(endDate)
            };

            dbContext.Trip.Attach(trip);
            dbContext.Entry(trip).Property(x => x.Title).IsModified = true;
            dbContext.Entry(trip).Property(x => x.StartDate).IsModified = true;
            dbContext.Entry(trip).Property(x => x.EndDate).IsModified = true;
            dbContext.SaveChanges();
        }
    }
}