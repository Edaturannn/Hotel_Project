using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DtoLayer.Dtos.CustomerDtos;
using HotelProject.DtoLayer.Dtos.SendMessageDtos;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ContactDtos;
using HotelProject.WebUI.Dtos.SendMessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IContactService _contactService;
        private readonly ISendMessageService _sendMessageService;
        private readonly IMapper _mapper;
        private readonly Context _context;
        public AdminContactController(IHttpClientFactory httpClientFactory, IContactService contactService, IMapper mapper, ISendMessageService sendMessageService, Context context)
        {
            _httpClientFactory = httpClientFactory;
            _contactService = contactService;
            _sendMessageService = sendMessageService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7212/api/Contact");
            if(responseMessage.IsSuccessStatusCode)
            {
                ViewBag.v1 = _context.Contacts.Count().ToString();
                ViewBag.v2 = _context.SendMessages.Count().ToString();
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7212/api/Contact/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7212/api/SendMessage");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);

                return View(values);
            }
            return View();
        }
        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<IActionResult> AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(SendMessage sendMessage)
        {
            await _sendMessageService.TInsertAsync(sendMessage);
            return RedirectToAction("Sendbox");
        }
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7212/api/Contact/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7212/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSendMessageDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

