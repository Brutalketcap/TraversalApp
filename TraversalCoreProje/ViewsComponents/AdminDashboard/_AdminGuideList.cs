using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TraversalCoreProje.ViewsComponents.AdminDashboard
{
    public class _AdminGuideList: ViewComponent  
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
