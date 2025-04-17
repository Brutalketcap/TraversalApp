using BusinessLayer.ValidationRules;
using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using DocumentFormat.OpenXml.Office.CustomUI;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {

            return View();
            //var values = _guideService.TGetList();
            //return View(values);
        }

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

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);

        }

        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdata(guide);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToTrue(int id)
        {
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToFalse(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
