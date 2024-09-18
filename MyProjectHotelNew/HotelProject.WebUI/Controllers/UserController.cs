using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DtoLayer.Dtos.SubsribeDtos;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.SubsribeDtos;
using HotelProject.WebUI.Models.Subsribe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly ISubsribeService _subsribeService;
        private readonly IMapper _mapper;
        public UserController(ISubsribeService subsribeService, IMapper mapper)
        {
            _subsribeService = subsribeService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubsribeDto createSubsribeDto)
        {
            if (!ModelState.IsValid)//Giriş başarılı değilse bu satır çalışacak...
            {
                return BadRequest();
            }
            var values = _mapper.Map<Subsribe>(createSubsribeDto);
            await _subsribeService.TInsertAsync(values);
            return View("Index");
        }
    }
}

