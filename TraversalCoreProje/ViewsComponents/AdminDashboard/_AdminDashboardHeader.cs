using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.AdminDashboard
{
    public class _AdminDashboardHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
