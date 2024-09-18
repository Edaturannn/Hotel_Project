using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RoomDtos;
using HotelProject.WebUI.Dtos.SubsribeDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebUI.Controllers
{
    [Authorize]
    public class AdminSubsribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly ISubsribeService _subsribeService;
        public AdminSubsribeController(IHttpClientFactory httpClientFactory, IMapper mapper, ISubsribeService subsribeService)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _subsribeService = subsribeService;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7212/api/Subsribe");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultSubsribeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteSubsribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7212/api/Subsribe/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddSubsribe()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSubsribe(CreateSubsribeDto createSubsribeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Subsribe>(createSubsribeDto);
            await _subsribeService.TInsertAsync(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubsribe(int id)
        {
            var values = _subsribeService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSubsribe(Subsribe subsribe)
        {
            await _subsribeService.TUpdateAsync(subsribe);
            return RedirectToAction("Index");
        }
    }
}

