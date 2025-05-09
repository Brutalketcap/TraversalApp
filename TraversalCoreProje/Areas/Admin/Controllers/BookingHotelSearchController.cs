using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&adults_number=2&page_number=0&children_number=2&include_adjacency=true&children_ages=5%2C0&locale=en-gb&dest_type=city&filter_by_currency=AED&dest_id=-1456928&order_by=popularity&units=metric&checkout_date=2025-10-15&room_number=1&checkin_date=2025-10-14"),
                Headers =
    {
        { "x-rapidapi-key", "54ccf7188bmshde2d8696faf41c5p140d5djsn716e3bec0512" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //var bodyReplace = body.Replace(".", "");

                var fixedBody = Regex.Replace(body, @"(?<=:\s*)([0-9]+)\.0(?![0-9])", "$1");

                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(fixedBody);


                return View(values.result);
            }
        }
        
        [HttpGet]
        public IActionResult GetCityDestID() 
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"),
                Headers =
    {
        { "x-rapidapi-key", "54ccf7188bmshde2d8696faf41c5p140d5djsn716e3bec0512" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                
            }
            return View();

        }
    }
}



