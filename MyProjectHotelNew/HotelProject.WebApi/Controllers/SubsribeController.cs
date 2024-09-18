using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.SubsribeDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SubsribeController : Controller
    {
        private readonly ISubsribeService _subsribeService;
        private readonly IMapper _mapper;
        public SubsribeController(ISubsribeService subsribeService, IMapper mapper)
        {
            _subsribeService = subsribeService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListSubsribe()
        {
            var values = _subsribeService.TGetList();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddSubsribe(SubsribeAddDto subsribeAddDto)
        {
            if(!ModelState.IsValid)//Giriş başarılı değilse bu satır çalışacak...
            {
                return BadRequest();
            }
            var values = _mapper.Map<Subsribe>(subsribeAddDto);
            await _subsribeService.TInsertAsync(values);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateSubsribe(SubsribeUpdateDto subsribeUpdateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Subsribe>(subsribeUpdateDto);
            await _subsribeService.TUpdateAsync(values);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubsribe(int id)
        {
            var values = _subsribeService.TGetByID(id);
            _subsribeService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIDSubsribe(int id)
        {
            var values = _subsribeService.TGetByID(id);
            return Ok(values);
        }
    }
}

