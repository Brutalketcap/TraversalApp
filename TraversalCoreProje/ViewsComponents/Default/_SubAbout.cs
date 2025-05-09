using BussinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManager subAboutManger = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = subAboutManger.TGetList();
            return View(values);
        }
    }
}
