using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApi.DAL;
using SignalRApi.Model;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VisitirController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitirController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public IActionResult CreatVisitor()
        {


            Random random = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        CityVisitorCount = random.Next(100, 2000),
                        VisitorDate = DateTime.Now.AddDays(x)
                    };
                    _visitorService.SaveVisitor(newVisitor).Wait();
                    System.Threading.Thread.Sleep(1000);
                }


            });
            return Ok("Ziyaretçiler başarı bir şekilde eklendi");

        }

    }
}
