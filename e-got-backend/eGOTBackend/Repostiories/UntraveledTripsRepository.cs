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
        public List<TripViewModel> Get(int touristId)
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
                    ElevationGain = x.ElevationGain,
                };
                tripViewModels.Add(tripViewModel);
            }

            return tripViewModels;
        }
    }
}