using DocumentFormat.OpenXml.Office2010.Excel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Commands.GuideCommands;
using TraversalCoreProje.CQRS.Queries.GuideQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class GuideMediaRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediaRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuides(int id)
        {
            var values = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(values);
        }
        
        [HttpGet]
        public IActionResult AddGuides()
        {
            
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddGuides(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
