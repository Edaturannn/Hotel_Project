using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IContactService contactService, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _contactService = contactService;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _AddContactPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _AddContactPartial(CreateContactDto createContactDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Contact>(createContactDto);
            await _contactService.TInsertAsync(values);
            return RedirectToAction("Index");
        }
    }
}

