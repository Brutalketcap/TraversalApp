using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.MemberLayout
{
    public class _MemberLayoutHeaderContent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
