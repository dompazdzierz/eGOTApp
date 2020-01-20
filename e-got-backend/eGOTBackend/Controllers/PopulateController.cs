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

        [HttpPost]
        [ActionName("location")]
        public IHttpActionResult Locations()
        {
            if (_dbContext.Location.Any())
            {
                return BadRequest("This entity is already populated.");
            }

            var locations = new List<Location>()
            {
                new Location {
                    Name="Rusinowa Polana",
                    Longtitude=50.032975f,
                    Latitude=18.800527f
                },
                new Location {
                    Name="Łysa Polana",
                    Longtitude=50.08702f,
                    Latitude=20.488659f
                },
                new Location {
                    Name="Gęsia Szyja",
                    Longtitude=50.005921f,
                    Latitude=18.965181f
                },
                new Location {
                    Name="Rówień Waksmundzka",
                    Longtitude=50.206888f,
                    Latitude=17.404295f
                },
                new Location {
                    Name="Psia Trawka",
                    Longtitude=50.613438f,
                    Latitude=19.065364f
                },
                new Location {
                    Name="Wodogrzmoty Mickiewicza",
                    Longtitude=50.028079f,
                    Latitude=16.901167f
                },
                new Location {
                    Name="Schronisko PTTK nad Morskim Okiem",
                    Longtitude=49.952028f,
                    Latitude=16.357878f
                },
                new Location {
                    Name="Czarny Staw nad Morskim Okiem",
                    Longtitude=50.273068f,
                    Latitude=22.293678f
                },
                new Location {
                    Name="Dolina za Mnichem",
                    Longtitude=50.210191f,
                    Latitude=16.722985f
                },
                new Location {
                    Name="Szpiglasowa Przełęcz",
                    Longtitude=49.78257f,
                    Latitude=16.388554f
                },
                new Location {
                    Name="Schronisko PTTK w Dolinie Pięciu Stawów Polskich",
                    Longtitude=50.465513f,
                    Latitude=20.192432f
                },
                new Location {
                    Name="Siklawa",
                    Longtitude=50.337198f,
                    Latitude=18.979093f
                },
                new Location {
                    Name="Kozi Wierch",
                    Longtitude=50.33875f,
                    Latitude=21.755458f
                },
                new Location {
                    Name="Kozia Przełęcz",
                    Longtitude=50.523417f,
                    Latitude=21.837682f
                },
                new Location {
                    Name="Przełęcz Zawrat",
                    Longtitude=49.762841f,
                    Latitude=20.408704f
                },
                new Location {
                    Name="Świnica",
                    Longtitude=49.743701f,
                    Latitude=18.153402f
                },
                new Location {
                    Name="Świnicka Przełęcz",
                    Longtitude=49.969999f,
                    Latitude=17.192217f
                },
                new Location {
                    Name="Kozia Dolinka",
                    Longtitude=50.749929f,
                    Latitude=16.520457f
                },
                new Location {
                    Name="Żleb Kulczyńskiego",
                    Longtitude=49.936332f,
                    Latitude=19.587628f
                },
                new Location {
                    Name="Skrajny Granat",
                    Longtitude=50.596358f,
                    Latitude=19.641857f
                },
                new Location {
                    Name="Przełęcz Krzyżne",
                    Longtitude=49.630144f,
                    Latitude=20.777019f
                },
                new Location {
                    Name="Przełęcz Krab",
                    Longtitude=49.639203f,
                    Latitude=18.54531f
                },
                new Location {
                    Name="Dwoiśniak",
                    Longtitude=50.204542f,
                    Latitude=21.590143f
                },
                new Location {
                    Name="Schronisko PTTK na Hali Gąsienicowej",
                    Longtitude=50.381043f,
                    Latitude=17.616347f
                },
                new Location {
                    Name="Droga \"Pod Reglami\"",
                    Longtitude=50.532181f,
                    Latitude=19.71401f
                },
                new Location {
                    Name="Polana Biały Potok",
                    Longtitude=49.670505f,
                    Latitude=18.250971f
                },
                new Location {
                    Name="Polana Huciska",
                    Longtitude=50.135471f,
                    Latitude=16.722798f
                },
                new Location {
                    Name="Niżnia Kominiarska Polana",
                    Longtitude=50.774054f,
                    Latitude=18.896104f
                },
                new Location {
                    Name="Schronisko PTTK na Polanie Chochołowskiej",
                    Longtitude=50.040728f,
                    Latitude=20.649755f
                },
                new Location {
                    Name="Trzydniowiański Wierch",
                    Longtitude=50.185892f,
                    Latitude=19.13488f
                },
                new Location {
                    Name="Jarząbczy Wierch",
                    Longtitude=50.066019f,
                    Latitude=21.829488f
                },
                new Location {
                    Name="Wołowiec",
                    Longtitude=49.824814f,
                    Latitude=19.719322f
                },
                new Location {
                    Name="Grześ",
                    Longtitude=49.763631f,
                    Latitude=20.585175f
                },
                new Location {
                    Name="Starorobociański Wierch",
                    Longtitude=50.315082f,
                    Latitude=20.572999f
                },
                new Location {
                    Name="Siwa Przełęcz",
                    Longtitude=50.057182f,
                    Latitude=18.432461f
                },
                new Location {
                    Name="Starorobociańska Rówień",
                    Longtitude=50.764044f,
                    Latitude=16.936198f
                },
                new Location {
                    Name="Iwaniacka Przełęcz",
                    Longtitude=49.573379f,
                    Latitude=18.405224f
                },
                new Location {
                    Name="Wyżnia Kira Miętusia",
                    Longtitude=49.821447f,
                    Latitude=22.059952f
                },
                new Location {
                    Name="Lodowe Źródło",
                    Longtitude=49.768956f,
                    Latitude=21.211205f
                },
                new Location {
                    Name="Polana Pisana",
                    Longtitude=49.549063f,
                    Latitude=19.419563f
                },
                new Location {
                    Name="Schronisko PTTK na Hali Ornak",
                    Longtitude=50.183951f,
                    Latitude=18.035541f
                },
                new Location {
                    Name="Wyżnia Tomanowa Polana",
                    Longtitude=50.573522f,
                    Latitude=21.874658f
                },
                new Location {
                    Name="Chuda Przełączka",
                    Longtitude=50.054984f,
                    Latitude=21.339679f
                },
                new Location {
                    Name="Krzesanica",
                    Longtitude=49.828999f,
                    Latitude=20.374189f
                },
                new Location {
                    Name="Przełęcz Przysłop Miętusi",
                    Longtitude=50.134879f,
                    Latitude=16.899523f
                },
                new Location {
                    Name="Kobylarz",
                    Longtitude=50.265005f,
                    Latitude=16.727307f
                },
                new Location {
                    Name="Wielka Polana w Dolinie Małej Łąki",
                    Longtitude=50.376484f,
                    Latitude=21.125247f
                },
                new Location {
                    Name="Kopa Kondracka",
                    Longtitude=50.578727f,
                    Latitude=16.593846f
                },
                new Location {
                    Name="Przełęcz Kondracka",
                    Longtitude=50.156185f,
                    Latitude=21.55174f
                },
                new Location {
                    Name="Przełęcz w Grzybowcu",
                    Longtitude=50.556855f,
                    Latitude=17.4084f
                },
                new Location {
                    Name="Polana Strążyska",
                    Longtitude=50.654282f,
                    Latitude=20.158203f
                },
                new Location {
                    Name="Czerwona Przełęcz",
                    Longtitude=50.184203f,
                    Latitude=18.166426f
                },
                new Location {
                    Name="Przełęcz Białego",
                    Longtitude=49.613344f,
                    Latitude=17.652161f
                },
                new Location {
                    Name="Schronisko PTTK na Hali Kondratowej",
                    Longtitude=50.543326f,
                    Latitude=21.987124f
                },
                new Location {
                    Name="Kasprowy Wierch",
                    Longtitude=49.903978f,
                    Latitude=16.859044f
                },
                new Location {
                    Name="Klasztor",
                    Longtitude=49.806614f,
                    Latitude=17.202031f
                },
                new Location {
                    Name="Kużnice",
                    Longtitude=50.088823f,
                    Latitude=18.704251f
                },
                new Location {
                    Name="Nosal",
                    Longtitude=49.752696f,
                    Latitude=19.602995f
                },
                new Location {
                    Name="Olczyska Polana",
                    Longtitude=49.831451f,
                    Latitude=18.57459f
                },
                new Location {
                    Name="Toporowa Cyrhla",
                    Longtitude=50.653462f,
                    Latitude=20.643823f
                },
                new Location {
                    Name="Magura Witowska TPG",
                    Longtitude=50.544107f,
                    Latitude=19.511631f
                },
                new Location {
                    Name="Palenica Kościeliska",
                    Longtitude=50.645131f,
                    Latitude=17.289032f
                },
                new Location {
                    Name="Butorowy Wierch",
                    Longtitude=50.122162f,
                    Latitude=16.428062f
                },
                new Location {
                    Name="Gubałówka",
                    Longtitude=50.127282f,
                    Latitude=19.145965f
                },
                new Location {
                    Name="Eliaszówka",
                    Longtitude=49.634455f,
                    Latitude=17.017933f
                },
                new Location {
                    Name="Szaflary",
                    Longtitude=50.382309f,
                    Latitude=19.329516f
                },
                new Location {
                    Name="Rafaczyńska Grapa",
                    Longtitude=50.439707f,
                    Latitude=22.127095f
                },
                new Location {
                    Name="Poronin",
                    Longtitude=49.721247f,
                    Latitude=20.249331f
                },
                new Location {
                    Name="Galicowa Grapa",
                    Longtitude=50.519315f,
                    Latitude=17.189147f
                },
                new Location {
                    Name="Bukowina Tatrzańska - Klin",
                    Longtitude=50.172471f,
                    Latitude=20.794558f
                },
                new Location {
                    Name="Głodówka",
                    Longtitude=49.875393f,
                    Latitude=21.992524f
                },
                new Location {
                    Name="Bukowina Tatrzańska Dolna",
                    Longtitude=49.842374f,
                    Latitude=20.707961f
                },
                new Location {
                    Name="Dzięgielów - Zamek",
                    Longtitude=50.676393f,
                    Latitude=16.953889f
                },
                new Location {
                    Name="Jasieniowa",
                    Longtitude=50.535963f,
                    Latitude=19.462012f
                },
                new Location {
                    Name="Schronisko PTTK Tuł",
                    Longtitude=50.382794f,
                    Latitude=16.354099f
                },
                new Location {
                    Name="Ostry",
                    Longtitude=49.562692f,
                    Latitude=17.973694f
                },
                new Location {
                    Name="Mała Czantoria",
                    Longtitude=50.672813f,
                    Latitude=17.540949f
                },
                new Location {
                    Name="Czantoria Wielka",
                    Longtitude=49.995209f,
                    Latitude=19.062249f
                },
                new Location {
                    Name="Wisła - Jawornik",
                    Longtitude=50.548335f,
                    Latitude=21.159255f
                },
                new Location {
                    Name="Soszów Wielki",
                    Longtitude=49.776763f,
                    Latitude=16.408199f
                },
                new Location {
                    Name="Schronisko PTTK Stożek",
                    Longtitude=49.925458f,
                    Latitude=17.518302f
                },
                new Location {
                    Name="Wisła - Jurzyków",
                    Longtitude=50.17418f,
                    Latitude=21.179267f
                },
                new Location {
                    Name="Wisła - Gościejów",
                    Longtitude=50.466346f,
                    Latitude=20.071132f
                },
                new Location {
                    Name="Wisła Nowa Osada",
                    Longtitude=49.785584f,
                    Latitude=16.411092f
                },
                new Location {
                    Name="Kozińce",
                    Longtitude=50.177983f,
                    Latitude=20.937381f
                },
                new Location {
                    Name="Przełęcz Kubalonka",
                    Longtitude=50.719921f,
                    Latitude=16.343566f
                },
                new Location {
                    Name="Mraźnica",
                    Longtitude=50.127485f,
                    Latitude=22.156391f
                },
                new Location {
                    Name="Kiczory",
                    Longtitude=49.592987f,
                    Latitude=17.433997f
                },
                new Location {
                    Name="Jaworzynka - Trzycatek",
                    Longtitude=49.896157f,
                    Latitude=22.249234f
                },
                new Location {
                    Name="Wierch Czadeczka",
                    Longtitude=49.554296f,
                    Latitude=20.607208f
                },
                new Location {
                    Name="Wielka Zabawa",
                    Longtitude=50.403882f,
                    Latitude=22.346707f
                },
                new Location {
                    Name="Przełęcz Koniakowska",
                    Longtitude=50.445839f,
                    Latitude=16.609098f
                },
                new Location {
                    Name="Koniaków",
                    Longtitude=49.848774f,
                    Latitude=19.856366f
                },
                new Location {
                    Name="Łączyna",
                    Longtitude=49.876707f,
                    Latitude=17.406632f
                },
                new Location {
                    Name="Kamesznica Dolna",
                    Longtitude=50.496787f,
                    Latitude=17.027966f
                },
                new Location {
                    Name="Kamesznica Złatna",
                    Longtitude=49.693799f,
                    Latitude=17.094407f
                },
                new Location {
                    Name="Schronisko PTTK Przysłop",
                    Longtitude=50.106536f,
                    Latitude=20.470272f
                },
                new Location {
                    Name="Wisła Czarne",
                    Longtitude=50.060288f,
                    Latitude=16.730367f
                },
                new Location {
                    Name="Wisła Czarne DW PTTK",
                    Longtitude=50.495539f,
                    Latitude=20.087585f
                },
                new Location {
                    Name="Barania Góra",
                    Longtitude=50.297897f,
                    Latitude=20.89555f
                },
                new Location {
                    Name="Magurka Wiślańska",
                    Longtitude=50.72962f,
                    Latitude=20.307586f
                },
                new Location {
                    Name="Magurka Radziechowska",
                    Longtitude=50.309611f,
                    Latitude=21.403421f
                },
                new Location {
                    Name="Grojec",
                    Longtitude=50.609216f,
                    Latitude=21.458859f
                },
                new Location {
                    Name="Zielony Kopiec",
                    Longtitude=50.680777f,
                    Latitude=16.777035f
                },
                new Location {
                    Name="Malinowska Skala",
                    Longtitude=50.148018f,
                    Latitude=18.576341f
                },
                new Location {
                    Name="Smerekowiec",
                    Longtitude=49.786229f,
                    Latitude=21.241351f
                },
                new Location {
                    Name="Trzy Kopce Wiślańskie",
                    Longtitude=50.345328f,
                    Latitude=21.103888f
                },
                new Location {
                    Name="Orłowa",
                    Longtitude=49.554756f,
                    Latitude=17.318614f
                },
                new Location {
                    Name="Schronisko PTTK Równica",
                    Longtitude=50.579486f,
                    Latitude=19.240569f
                },
                new Location {
                    Name="Górki Wielkie",
                    Longtitude=50.64659f,
                    Latitude=16.773185f
                },
                new Location {
                    Name="Łazek",
                    Longtitude=49.736981f,
                    Latitude=17.705461f
                },
                new Location {
                    Name="Schronisko PTTK Błatnia",
                    Longtitude=49.609141f,
                    Latitude=16.402553f
                },
                new Location {
                    Name="Jezioro w dolinie Wapiennicy",
                    Longtitude=49.564906f,
                    Latitude=19.979356f
                },
                new Location {
                    Name="Stary Groń",
                    Longtitude=50.172267f,
                    Latitude=21.381291f
                },
                new Location {
                    Name="Przełęcz Salmopolska",
                    Longtitude=50.028299f,
                    Latitude=21.673318f
                },
                new Location {
                    Name="Kotarz",
                    Longtitude=49.917074f,
                    Latitude=21.574084f
                },
                new Location {
                    Name="Schronisko PTTK Skrzyczne",
                    Longtitude=50.286012f,
                    Latitude=20.594782f
                },
                new Location {
                    Name="Przełęcz Karkoszonka",
                    Longtitude=50.679632f,
                    Latitude=19.570514f
                },
                new Location {
                    Name="Klimczok",
                    Longtitude=50.555085f,
                    Latitude=18.201968f
                },
                new Location {
                    Name="Schronisko PTTK Klimczok",
                    Longtitude=50.033719f,
                    Latitude=17.052516f
                },
                new Location {
                    Name="Meszna",
                    Longtitude=50.155754f,
                    Latitude=18.291198f
                },
                new Location {
                    Name="Schronisko PTTK Szyndzielnia",
                    Longtitude=49.655681f,
                    Latitude=17.188863f
                },
                new Location {
                    Name="Mikuszowice Śląskie",
                    Longtitude=50.560221f,
                    Latitude=17.51044f
                },
                new Location {
                    Name="Kozia Góra",
                    Longtitude=50.070605f,
                    Latitude=17.453014f
                },
                new Location {
                    Name="Przełęcz Kołowrót",
                    Longtitude=50.263115f,
                    Latitude=16.365793f
                },
                new Location {
                    Name="Rachowiec",
                    Longtitude=50.105866f,
                    Latitude=19.976596f
                },
                new Location {
                    Name="Bór",
                    Longtitude=49.965643f,
                    Latitude=17.015929f
                },
                new Location {
                    Name="Ożna",
                    Longtitude=50.650941f,
                    Latitude=16.22523f
                },
                new Location {
                    Name="Łysica",
                    Longtitude=50.691848f,
                    Latitude=18.942336f
                },
                new Location {
                    Name="Magura",
                    Longtitude=50.612916f,
                    Latitude=18.783391f
                },
                new Location {
                    Name="Schronisko PTTK Wielka Racza",
                    Longtitude=50.63264f,
                    Latitude=18.646857f
                },
                new Location {
                    Name="Schronisko PTTK na Przełęczy Przegibek",
                    Longtitude=50.65806f,
                    Latitude=16.77034f
                },
                new Location {
                    Name="Rycerki",
                    Longtitude=50.126412f,
                    Latitude=21.524874f
                },
                new Location {
                    Name="Młada Hora",
                    Longtitude=49.601941f,
                    Latitude=17.049026f
                },
                new Location {
                    Name="Urówka",
                    Longtitude=50.580494f,
                    Latitude=18.353572f
                },
                new Location {
                    Name="Wielka Rycerzowa",
                    Longtitude=50.38299f,
                    Latitude=21.50747f
                },
                new Location {
                    Name="Bacówka PTTK na Rycerzowej",
                    Longtitude=50.497847f,
                    Latitude=22.231092f
                },
                new Location {
                    Name="Muńcuł",
                    Longtitude=49.756996f,
                    Latitude=16.389513f
                },
                new Location {
                    Name="&nbsp;Bednarów Beskid",
                    Longtitude=50.530857f,
                    Latitude=18.282335f
                },
                new Location {
                    Name="Jaworzyna",
                    Longtitude=50.206982f,
                    Latitude=20.378865f
                },
                new Location {
                    Name="Soblówka",
                    Longtitude=50.665508f,
                    Latitude=16.610885f
                },
                new Location {
                    Name="Glinka",
                    Longtitude=50.642362f,
                    Latitude=19.592033f
                },
                new Location {
                    Name="Bacówka PTTK Krawców Wierch",
                    Longtitude=49.790272f,
                    Latitude=18.675422f
                },
                new Location {
                    Name="Hala Redykalna",
                    Longtitude=50.607852f,
                    Latitude=16.693091f
                },
                new Location {
                    Name="Sucha Góra",
                    Longtitude=49.953857f,
                    Latitude=17.715246f
                },
                new Location {
                    Name="Schronisko PTTK na Hali Boraczej",
                    Longtitude=49.982963f,
                    Latitude=17.48679f
                },
                new Location {
                    Name="Schronisko PTTK Hala Lipowska",
                    Longtitude=50.029744f,
                    Latitude=16.599662f
                },
                new Location {
                    Name="Schronisko PTTK Hala Rysianka",
                    Longtitude=49.73778f,
                    Latitude=18.307256f
                },
                new Location {
                    Name="Romanka",
                    Longtitude=50.322282f,
                    Latitude=17.684956f
                },
                new Location {
                    Name="Sopotnia Wielka - Kolonia",
                    Longtitude=49.562355f,
                    Latitude=21.433066f
                },
                new Location {
                    Name="Słowianka",
                    Longtitude=50.291212f,
                    Latitude=20.838435f
                },
                new Location {
                    Name="Kiczora",
                    Longtitude=49.638968f,
                    Latitude=19.919822f
                },
                new Location {
                    Name="Jastrzębica",
                    Longtitude=50.093384f,
                    Latitude=20.012242f
                },
                new Location {
                    Name="Pilsko",
                    Longtitude=50.730491f,
                    Latitude=21.828552f
                },
                new Location {
                    Name="Schronisko PTTK na Hali Miziowej",
                    Longtitude=50.116691f,
                    Latitude=18.546868f
                },
                new Location {
                    Name="Kamienna",
                    Longtitude=50.683323f,
                    Latitude=20.026712f
                },
            };

            _dbContext.Location.AddRange(locations);
            _dbContext.SaveChanges();
            return Ok(locations);
        }

        [HttpPost]
        [ActionName("section")]
        public IHttpActionResult Sections()
        {
            if (_dbContext.Section.Any())
            {
                return BadRequest("This entity is already populated.");
            }

            int id0 = _dbContext.Location.Where(x => x.Name == "Rusinowa Polana").Select(x => x.Id).FirstOrDefault();
            int id3 = _dbContext.Location.Where(x => x.Name == "Rówień Waksmundzka").Select(x => x.Id).FirstOrDefault();
            int id6 = _dbContext.Location.Where(x => x.Name == "Schronisko PTTK nad Morskim Okiem").Select(x => x.Id).FirstOrDefault();
            int id13 = _dbContext.Location.Where(x => x.Name == "Kozia Przełęcz").Select(x => x.Id).FirstOrDefault();
            int id11 = _dbContext.Location.Where(x => x.Name == "Siklawa").Select(x => x.Id).FirstOrDefault();
            int id22 = _dbContext.Location.Where(x => x.Name == "Dwoiśniak").Select(x => x.Id).FirstOrDefault();
            int id1 = _dbContext.Location.Where(x => x.Name == "Łysa Polana").Select(x => x.Id).FirstOrDefault();

            int tatrwys = _dbContext.MountainRange.Where(x => x.Name == "Tatry Wysokie").Select(x => x.Id).FirstOrDefault();

            var sections = new List<Section>()
            {
                new Section {
                    StartLocation = id0,
                    EndLocation = id3,
                    Length = 3866f,
                    ElevationGain = 336f,
                    Score = 6,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {
                    StartLocation = id3,
                    EndLocation = id0,
                    Length = 3866f,
                    ElevationGain = 336f,
                    Score = 6,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {
                    StartLocation = id0,
                    EndLocation = id6,
                    Length = 4101f,
                    ElevationGain = 146f,
                    Score = 5,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {
                    StartLocation = id6,
                    EndLocation = id0,
                    Length = 4101f,
                    ElevationGain = 146f,
                    Score = 6,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {
                    StartLocation = id0,
                    EndLocation = id13,
                    Length = 4059f,
                    ElevationGain = 297f,
                    Score = 6,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {
                    StartLocation = id13,
                    EndLocation = id0,
                    Length = 4059f,
                    ElevationGain = 297f,
                    Score = 7,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {
                    StartLocation = id0,
                    EndLocation = id11,
                    Length = 803f,
                    ElevationGain = 255f,
                    Score = 2,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {
                    StartLocation = id11,
                    EndLocation = id0,
                    Length = 803f,
                    ElevationGain = 255f,
                    Score = 2,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {
                    StartLocation = id0,
                    EndLocation = id22,
                    Length = 1767f,
                    ElevationGain = 54f,
                    Score = 1,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {
                    StartLocation = id22,
                    EndLocation = id0,
                    Length = 1767f,
                    ElevationGain = 54f,
                    Score = 2,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {

                    StartLocation = id1,
                    EndLocation = id6,
                    Length = 2893f,
                    ElevationGain = 292f,
                    Score = 4,
                    Status = true,
                    MountainRange = tatrwys
                },
                new Section {

                    StartLocation = id6,
                    EndLocation = id1,
                    Length = 2893f,
                    ElevationGain = 292f,
                    Score = 4,
                    Status = true,
                    MountainRange = tatrwys
                }
            };

            _dbContext.Section.AddRange(sections);
            _dbContext.SaveChanges();
            return Ok(sections);
        }
    }
}