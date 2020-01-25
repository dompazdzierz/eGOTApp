using eGOTBackend.Models;
using eGOTBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eGOTBackend.Repostiories
{
    public class TraveledTripsRepository : BaseRepository
    {
        public List<TripViewModel> GetAll()
        {
            var trips = dbContext.Trip
                .Where(x => x.Status == 1)
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
                    ElevationGain = x.ElevationGain,
                };
                tripViewModels.Add(tripViewModel);
            }

            return tripViewModels;
        }

        public TripViewModel Get(int id)
        {
            var trip = dbContext.Trip
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (trip == null)
            {
                return null;
            }

            var photos = dbContext.PhotoProof
                .Where(x => x.IdTrip == id)
                .Select(x => x.PhotoUrl)
                .ToList();

            return new TripViewModel
            {
                Id = trip.Id,
                Title = trip.Title,
                StartDate = trip.StartDate.ToString("dd.MM.yyyy"),
                EndDate = trip.EndDate.ToString("dd.MM.yyyy"),
                Score = trip.Score,
                Length = trip.Length,
                ElevationGain = trip.ElevationGain,
                Route = "Palenica Białczańska - Wodogrzmoty Mickiewicza - Schronisko PTTK nad Morksim Okiem - Wodogrzmoty Mickiewicza - Palenica Białczańska",
                Photos = photos
            };
        }
    }
}