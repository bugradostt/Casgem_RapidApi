using Casgem_RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapidApi.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //using System.Net.Http.Headers;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
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
               var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.exchange_rates.ToList());
            }
            return View();
        }

        public async Task<IActionResult> InputIndex(string s="TRY")
        {
            //using System.Net.Http.Headers;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency={s}&locale=en-gb"),
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
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.exchange_rates.ToList());
            }
            return View();
        }
    }
}
