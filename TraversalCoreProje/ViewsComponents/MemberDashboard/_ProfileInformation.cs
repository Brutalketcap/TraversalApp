using BussinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.MemberDashboard
{
    public class _ProfileInformation: ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var vaules = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.memberName = vaules.Name+ " " + vaules.Surname;
            ViewBag.memberPhone = vaules.PhoneNumber;
            ViewBag.memberEmail= vaules.Email;
            return View();
        }
    }
}
