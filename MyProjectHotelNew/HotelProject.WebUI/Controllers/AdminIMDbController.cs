using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.WebUI.Dtos.IMDbDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebUI.Controllers
{
    public class AdminIMDbController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            List<ResultIMDbDto> resultIMDbDto = new List<ResultIMDbDto>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "630ce9cc86msh271c60cffe62d5ep1b514djsn0fe292593744" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                resultIMDbDto = JsonConvert.DeserializeObject<List<ResultIMDbDto>>(body);
                return View(resultIMDbDto);
            }
        }
    }
}

