using eGOTBackend.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGOTBackend.Repostiories
{
    public class UntraveledTripsRepository : BaseRepository
    {
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
    }
}