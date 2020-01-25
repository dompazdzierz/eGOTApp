using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using eGOTBackend.Models;
using System.Web.Http.Cors;
using System.Json;
using System.IO;
using System;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PopulateController : ApiController {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpPost]
        [ActionName("all")]
        public IHttpActionResult Populate()
        {
            _populateMountainSystems();
            _populateMountainRanges();
            _populateLocations();
            _populateSections();
            _populateTourist();
            _populateTrips();
            _populatePhotos();
            return Ok();
        }

        private void _populateMountainSystems()
        {
            using (StreamReader sr = new StreamReader(HttpRuntime.AppDomainAppPath + "/PopulateData/mountainSystems.json"))
            {
                string json_string = sr.ReadToEnd();
                JsonValue json = JsonValue.Parse(json_string);

                ICollection<MountainSystem> mountainSystems = new List<MountainSystem>();

                foreach (JsonValue value in json)
                {
                    mountainSystems.Add(new MountainSystem
                    {
                        Name = value["name"]
                    });
                }

                _dbContext.MountainSystem.AddRange(mountainSystems);
                _dbContext.SaveChanges();
            }
        }

        private void _populateMountainRanges()
        {
            using (StreamReader sr = new StreamReader(HttpRuntime.AppDomainAppPath + "/PopulateData/mountainRanges.json"))
            {
                string json_string = sr.ReadToEnd();
                JsonValue json = JsonValue.Parse(json_string);

                ICollection<MountainRange> mountainRanges = new List<MountainRange>();

                foreach (JsonValue value in json)
                {
                    mountainRanges.Add(new MountainRange
                    {
                        Name = value["name"],
                        MountainSystemId = _dbContext.MountainSystem.AsNoTracking()
                            .Where(x => x.Name == value["mountainRange"])
                            .Select(x => x.Id)
                            .FirstOrDefault()
                    });
                }

                _dbContext.MountainRange.AddRange(mountainRanges);
                _dbContext.SaveChanges();
            }
        }

        private void _populateLocations()
        {
            using (StreamReader sr = new StreamReader(HttpRuntime.AppDomainAppPath + "/PopulateData/locations.json"))
            {
                string json_string = sr.ReadToEnd();
                JsonValue json = JsonValue.Parse(json_string);

                ICollection<Location> locations = new List<Location>();

                foreach (JsonValue value in json)
                {
                    locations.Add(new Location
                    {
                        Name = value["name"],
                        Longtitude = value["longitude"],
                        Latitude = value["latitude"]
                    });
                }

                _dbContext.Location.AddRange(locations);
                _dbContext.SaveChanges();
            }
        }

        private void _populateSections()
        {
            using (StreamReader sr = new StreamReader(HttpRuntime.AppDomainAppPath + "/PopulateData/sections.json"))
            {
                string json_string = sr.ReadToEnd();
                JsonValue json = JsonValue.Parse(json_string);

                ICollection<Section> sections = new List<Section>();

                foreach (JsonValue value in json)
                {
                    sections.Add(new Section
                    {
                        StartLocationId = _dbContext.Location.AsNoTracking()
                            .Where(x => x.Name == value["startLocation"])
                            .Select(x => x.Id)
                            .FirstOrDefault(),
                        EndLocationId = _dbContext.Location.AsNoTracking()
                            .Where(x => x.Name == value["endLocation"])
                            .Select(x => x.Id)
                            .FirstOrDefault(),
                        Length = value["length"],
                        ElevationGain = value["elevationGain"],
                        Score = value["score"],
                        Status = value["status"],
                        MountainRangeId = _dbContext.MountainRange.AsNoTracking()
                            .Where(x => x.Name == value["mountainRange"])
                            .Select(x => x.Id)
                            .FirstOrDefault()
                    });
                }

                _dbContext.Section.AddRange(sections);
                _dbContext.SaveChanges();
            }
        }

        private void _populateTourist()
        {
            _dbContext.Users.Add(new Users
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jankowalski@gmail.com",
                Password = "zmn7MQS^YfGfPBN@fCkPb5^qHy55@@UT"
            });
            _dbContext.SaveChanges();

            _dbContext.BadgeLevel.Add(new BadgeLevel
            {
                Name = "Super odznaka",
                RequiredPoints = 69
            });
            _dbContext.SaveChanges();

            int userId = _dbContext.Users
                .Where(x => x.Email == "jankowalski@gmail.com")
                .Select(x => x.Id)
                .FirstOrDefault();

            int badgeLevelId = _dbContext.BadgeLevel
                .Where(x => x.Name == "Super odznaka")
                .Select(x => x.Id)
                .FirstOrDefault();

            _dbContext.Tourist.Add(new Tourist
            {
                IdUser = userId,
                DateOfBirth = DateTime.Now,
                IsDisabled = false,
                AllPoints = 689,
                ConfirmedPoints = 676,
                IdBadgeLevel = badgeLevelId
            });
            _dbContext.SaveChanges();
        }

        private void _populateTrips()
        {
            using (StreamReader sr = new StreamReader(HttpRuntime.AppDomainAppPath + "/PopulateData/trips.json"))
            {
                string json_string = sr.ReadToEnd();
                JsonValue json = JsonValue.Parse(json_string);

                int touristId = _dbContext.Tourist
                    .Select(x => x.IdUser)
                    .FirstOrDefault();

                ICollection<Trip> trips = new List<Trip>();

                foreach (JsonValue value in json)
                {
                    trips.Add(new Trip
                    {
                        Title = value["title"],
                        StartDate = DateTime.Parse(value["startDate"]),
                        EndDate = DateTime.Parse(value["endDate"]),
                        Status = value["status"],
                        Score = value["score"],
                        Length = value["length"],
                        ElevationGain = value["elevationGain"],
                        IdTourist = touristId
                    });
                }

                _dbContext.Trip.AddRange(trips);
                _dbContext.SaveChanges();
            }
        }

        private void _populatePhotos()
        {
            using (StreamReader sr = new StreamReader(HttpRuntime.AppDomainAppPath + "/PopulateData/photoProofs.json"))
            {
                string json_string = sr.ReadToEnd();
                JsonValue json = JsonValue.Parse(json_string);

                ICollection<PhotoProof> photo_proofs = new List<PhotoProof>();

                foreach (JsonValue value in json)
                {
                    photo_proofs.Add(new PhotoProof
                    {
                        IdTrip = _dbContext.Trip
                            .Where(x => x.Title == value["title"])
                            .Select(x => x.Id)
                            .FirstOrDefault(),
                        PhotoUrl = value["path"]
                    });
                }

                _dbContext.PhotoProof.AddRange(photo_proofs);
                _dbContext.SaveChanges();
            }
        }
    }
}