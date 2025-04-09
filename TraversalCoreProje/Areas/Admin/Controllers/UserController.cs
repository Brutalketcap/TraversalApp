using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    { 
        private readonly IAppUserService _appUserService;

        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            
            return View(values);
        }

        public IActionResult DelateUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
         }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TUpdata(appUser);
            return RedirectToAction("Index");
        }
        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }
        public IActionResult ReservationUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }
    }
}
