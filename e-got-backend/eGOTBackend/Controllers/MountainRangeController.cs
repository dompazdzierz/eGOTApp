//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace eGOTBackend.Controllers
//{
//    using System.Web.Http.Cors;
//    using System.Web.Http;
//    using System.Collections.Generic;
//    using System.Linq;
//    using eGOTBackend.Models;

//    namespace eGOTBackend.Controllers
//    {
//        [RoutePrefix("sections")]
//        [EnableCors(origins: "*", headers: "*", methods: "*")]
//        public class SectionController : ApiController
//        {
//            static List<Section> sectionList = new List<Section>();

//            [HttpGet]
//            public IEnumerable<Section> Get()
//            {
//                return sectionList;
//            }

//            [HttpPost]
//            public Section Post(Section section)
//            {
//                var ids = sectionList.Select(x => x.Id);
//                section.Id = ids.Count() == 0 ? 0 : ids.Max() + 1;
//                sectionList.Add(section);
//                return section;
//            }

//        }
//    }

//}