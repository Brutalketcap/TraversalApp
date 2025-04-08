using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.AdminDashboard
{
    public class _Cards1Statistic : ViewComponent
    {
        Context context= new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1=context.Destinations.Count();
            ViewBag.v2=context.Users.Count();
            return View();
        }
    }  
    

    
}
