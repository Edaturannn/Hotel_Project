using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDtos;
using HotelProject.WebUI.Dtos.BookingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly IAboutService _aboutService;
        public AdminAboutController(IHttpClientFactory httpClientFactory, IMapper mapper, IAboutService aboutService)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _aboutService = aboutService;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7212/api/About");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7212/api/About/{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutDto createAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<About>(createAboutDto);
            await _aboutService.TInsertAsync(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(About about)
        {
            await _aboutService.TUpdateAsync(about);
            return RedirectToAction("Index");
        }
    }
}

