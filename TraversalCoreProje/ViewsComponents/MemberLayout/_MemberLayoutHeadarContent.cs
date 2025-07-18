using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.MemberLayout
{
    public class _MemberLayoutHeadarContent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
