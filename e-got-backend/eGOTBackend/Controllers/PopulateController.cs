using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using eGOTBackend.Models;
using System.Web.Http.Cors;

namespace eGOTBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PopulateController : ApiController {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpPost]
        [ActionName("mountainsystem")]
        public IHttpActionResult MountainSystems()
        {
            if(_dbContext.MountainSystem.Any())
            {
                return BadRequest("This entity is already populated.");
            }

            var mountainSystems = new List<MountainSystem>()
                {
                    new MountainSystem {
                        Name="Tatry i Podtatrze"
                    },
                    new MountainSystem {
                        Name="Beskidy Zachodnie"
                    },
                    new MountainSystem {
                        Name="Beskidy Wschodnie"
                    },
                    new MountainSystem {
                        Name="Sudety"
                    }
                };

            _dbContext.MountainSystem.AddRange(mountainSystems);
            _dbContext.SaveChanges();
            return Ok(mountainSystems);
        }

        [HttpPost]
        [ActionName("mountainrange")]
        public IHttpActionResult MountainRanges()
        {
            if (_dbContext.MountainRange.Any())
            {
                return BadRequest("This entity is already populated.");
            }

            int id0 = _dbContext.MountainSystem.Where(x => x.Name == "Tatry i Podtatrze").Select(x => x.Id).FirstOrDefault(); 
            int id1 = _dbContext.MountainSystem.Where(x => x.Name == "Beskidy Zachodnie").Select(x => x.Id).FirstOrDefault();

            var mountainRanges = new List<MountainRange>()
            {
                new MountainRange {
                    Name="Tatry Wysokie",
                    MountainSystemId=id0
                },
                new MountainRange {
                    Name="Tatry Zachodnie",
                    MountainSystemId=id0
                },
                new MountainRange {
                    Name="Podtatrze",
                    MountainSystemId=id0
                },
                new MountainRange {
                    Name="Beskid Śląski",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Beskid Żywiecki",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Beskid Mały",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Beskid Średni",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Gorce",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Beskid Wyspowy",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Orawa",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Spisz i Pieniny",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Beskid Sądecki",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Pogórze Wielickie",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Pogórze Wiśnickie",
                    MountainSystemId=id1
                },
                new MountainRange {
                    Name="Pogórze Rożnowskie",
                    MountainSystemId=id1
                },
            };

            _dbContext.MountainRange.AddRange(mountainRanges);
            _dbContext.SaveChanges();
            return Ok(mountainRanges);
        }

    }
}