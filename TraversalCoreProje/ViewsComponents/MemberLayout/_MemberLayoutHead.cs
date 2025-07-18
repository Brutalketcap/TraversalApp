using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.MemberLayout
{
    public class _MemberLayoutHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
