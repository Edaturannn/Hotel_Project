using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebUI.Controllers
{
    public class AdminFileProcessController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);

            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

            var client = new HttpClient();
            await client.PostAsync("https://localhost:7212/api/FileProcess", multipartFormDataContent);
            return View();
        }
    }
}

