using Casgem_RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapidApi.Controllers
{
    public class CityLocationController : Controller
    {
        public async Task<IActionResult> Index(string cityName="London")
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
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
                var values = JsonConvert.DeserializeObject<List<LocationCityViewModel>>(body);
                return View(values.Take(1).ToList());
            }
       
        }
    }
}
