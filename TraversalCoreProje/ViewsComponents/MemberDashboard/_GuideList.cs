using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.MemberDashboard
{
    public class _GuideList :  ViewComponent
    {
        GuideManager guideManger = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = guideManger.TGetList();
            return View(values);
        }
    }
}
