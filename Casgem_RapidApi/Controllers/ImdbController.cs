using Casgem_RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapidApi.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                    {
                        { "X-RapidAPI-Key", "aeb8f45ed7msh84ae8780847a6f8p165fe9jsnb553c7e0184f" },
                        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
               var  model= JsonConvert.DeserializeObject<List<ImdbMovieListViewModal>>(body);
                return View(model.ToList());
            }
            return View();
        }
    }
}
