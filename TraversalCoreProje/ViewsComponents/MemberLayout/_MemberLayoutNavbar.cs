using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.MemberLayout
{
    public class _MemberLayoutNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
