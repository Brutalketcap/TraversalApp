using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.Default
{
    public class _Testimonial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
