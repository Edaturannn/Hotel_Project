using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RoomDtos;
using HotelProject.WebUI.Dtos.StaffDtos;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebUI.Controllers
{
    [Authorize]
    public class AdminStaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly IStaffService _staffService;
        public AdminStaffController(IHttpClientFactory httpClientFactory, IMapper mapper, IStaffService staffService)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _staffService = staffService;
        }
        //Staff API Controller daki verileri listeliyor...
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7212/api/Staff");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        //Staff API Controller daki verileri seçilen ID ye göre siliyor..
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7212/api/Staff/{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(CreateStaffDto createStaffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Staff>(createStaffDto);
            await _staffService.TInsertAsync(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var values = _staffService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(Staff staff)
        {
            await _staffService.TUpdateAsync(staff);
            return RedirectToAction("Index");
        }
    }
}

