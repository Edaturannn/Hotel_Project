using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.CustomerDtos;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.CustomerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebUI.Controllers
{
    public class AdminCustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICustomerService _customerService;
        public AdminCustomerController(IHttpClientFactory httpClientFactory, ICustomerService customerService)
        {
            _httpClientFactory = httpClientFactory;
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7212/api/Customer");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7212/api/Customer/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            await _customerService.TInsertAsync(customer);
            return RedirectToAction("Index");
        }
    }
}

