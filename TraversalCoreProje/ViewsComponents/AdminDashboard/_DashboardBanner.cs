using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.AdminDashboard
{
    public class _DashboardBanner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
