using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Handers.DestinationHanders;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHanders _getAllDestinationQueryHanders;

        public DestinationCQRSController(GetAllDestinationQueryHanders getAllDestinationQueryHanders)
        {
            _getAllDestinationQueryHanders = getAllDestinationQueryHanders;
        }

        public IActionResult Index()
        {
            var values= _getAllDestinationQueryHanders.Handle();
            return View(values);
        }
    }
}
