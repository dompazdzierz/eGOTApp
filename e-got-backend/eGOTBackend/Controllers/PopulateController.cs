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
                        StartLocation = _dbContext.Location.AsNoTracking()
                            .Where(x => x.Name == value["startLocation"])
                            .Select(x => x.Id)
                            .FirstOrDefault(),
                        EndLocation = _dbContext.Location.AsNoTracking()
                            .Where(x => x.Name == value["endLocation"])
                            .Select(x => x.Id)
                            .FirstOrDefault(),
                        Length = value["length"],
                        ElevationGain = value["elevationGain"],
                        Score = value["score"],
                        Status = value["status"],
                        MountainRange = _dbContext.MountainRange.AsNoTracking()
                            .Where(x => x.Name == value["mountainRange"])
                            .Select(x => x.Id)
                            .FirstOrDefault()
                    });
                }

                _dbContext.Section.AddRange(sections);
                _dbContext.SaveChanges();
            }
        }
    }
}