using BussinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.Default
{
    public class _PopularDestinations: ViewComponent
    {

        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
    }
}
