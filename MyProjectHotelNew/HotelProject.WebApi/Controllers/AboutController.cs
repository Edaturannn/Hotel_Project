using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.AboutDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListAbout()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAbout(AboutAddDto aboutAddDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<About>(aboutAddDto);
            await _aboutService.TInsertAsync(values);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(AboutUpdateDto aboutUpdateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<About>(aboutUpdateDto);
            await _aboutService.TUpdateAsync(values);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIDAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            return Ok(values);
        }
    }
}

