using Casgem_RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapidApi.Controllers
{
    public class BookingController : Controller
    {
      
        public async Task<IActionResult> Index(string cityID= "-553173", string roomnumber="1", 
            string checkoutdate= "2023-09-27",
            string checkindate = "2023-09-28", string child = "2",  string adult = "2")
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number=2&checkin_date=2023-09-27&filter_by_currency=AED&dest_id=-553173&locale=en-gb&checkout_date=2023-09-28&units=metric&room_number=1&dest_type=city&include_adjacency=true&children_number=2&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
               // RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number={adult}&checkin_date={checkindate}&filter_by_currency=AED&dest_id={cityID}&locale=en-gb&checkout_date={checkoutdate}&units=metric&room_number={roomnumber}&dest_type=city&include_adjacency=true&children_number={child}&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                Headers =
            {
                { "X-RapidAPI-Key", "aeb8f45ed7msh84ae8780847a6f8p165fe9jsnb553c7e0184f" },
                { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<HotelListViewModel>(body);
                return View(values.results.ToList());
            }
            return View();
        }

      
    }
}
