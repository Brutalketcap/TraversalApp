using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationServce _destinationServce;

        public CityController(IDestinationServce destinationServce)
        {
            _destinationServce = destinationServce;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {
            var destinations = _destinationServce.TGetList();
            return Json(destinations);

            //var jsonCity = JsonConvert.SerializeObject(_destinationServce.TGetList());
            //return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationServce.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);

            return Json(values);
        }
        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationServce.TGetByID(DestinationID);
            //var jasonValues = JsonConvert.SerializeObject(values);
            return Json(values);

        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationServce.TGetByID(id);
            _destinationServce.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {

            _destinationServce.TUpdata(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }
        //public static List<CityClass> cities = new List<CityClass>
        //{ //cities
        //    new CityClass
        //    {
        //        CityID=1,
        //        CityName="Üsküp",
        //        CityCountry="Makadonya"
        //    },
        //    new CityClass
        //    {
        //        CityID=2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //    new CityClass
        //    {
        //        CityID=3,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //    }
        //};

    }
}
