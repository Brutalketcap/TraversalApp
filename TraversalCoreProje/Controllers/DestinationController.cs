using BussinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
        
        [HttpGet]
        public IActionResult DestinationDetails(int id) 
        {
            ViewBag.i = id;
            var values= destinationManager.TGetByID(id);
            if (values == null)
            {
                 
                return NotFound();
            }
            return View(values);
        }
        
        [HttpPost]
        public IActionResult DestinationDetail(Destination p)
        {
            return View();
        }
    }
}
