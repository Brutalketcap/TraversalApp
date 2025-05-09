using BusinessLayer.ValidationRules;
using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {

            return View();
            //var values = _guideService.TGetList();
            //return View(values);
        }

        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {

            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            if (result.IsValid)
            {

                _guideService.TAdd(guide);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var itme in result.Errors)
                {
                    ModelState.AddModelError(itme.PropertyName, itme.ErrorMessage);
                }
                return View();
            }
        }

        [Route("EditGuide")]
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);

        }

        [Route("EditGuide")]
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdata(guide);
            return RedirectToAction("Index");
        }

        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTureByGuid(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuid(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
