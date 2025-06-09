using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<PartialViewResult> AddComment(int id)
        {
           
            ViewBag.i = id;
            ViewBag.destID = id;
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.userID = values.Id;

            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            p.CommentUser = HttpContext.Session.GetString("username");
            commentManager.TAdd(p);
            return RedirectToAction("Index", "Destination");
        }
    }
}
