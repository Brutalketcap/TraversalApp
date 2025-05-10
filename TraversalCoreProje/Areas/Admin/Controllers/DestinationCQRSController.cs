using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;
using TraversalCoreProje.CQRS.Handers.DestinationHanders;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHanders _getAllDestinationQueryHanders;
        private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHanders getAllDestinationQueryHanders, GetDestinationByIDQueryHandler getDestinationByIDQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHanders = getAllDestinationQueryHanders;
            _getDestinationByIDQueryHandler = getDestinationByIDQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHanders.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));


            return View(values);
        }
        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommend commend)
        {
            _updateDestinationCommandHandler.Handle(commend);


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDestination() 
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);

            return RedirectToAction("Index");
        }

        
        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));

            return RedirectToAction("Index");
        }
    }
}
