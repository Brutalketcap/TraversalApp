using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewsComponents.Default
{
    public class _Testimonial: ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var value = testimonialManager.TGetList();
            return View(value);
        }
    }
}
