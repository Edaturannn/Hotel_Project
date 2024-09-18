using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class FileProcessController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "files/" + fileName);

            var stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream);

            return Created("", file);
        }
    }
}

