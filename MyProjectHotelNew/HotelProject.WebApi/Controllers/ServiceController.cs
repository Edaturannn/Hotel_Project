using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.ServiceDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;
        public ServiceController(IServiceService serviceService,IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListService()
        {
            var values = _serviceService.TGetList();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddService(ServiceAddDto serviceAddDto)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var values = _mapper.Map<Service>(serviceAddDto);
            await _serviceService.TInsertAsync(values);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateService(ServiceUpdateDto serviceUpdateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Service>(serviceUpdateDto);
            await _serviceService.TUpdateAsync(values);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetByID(id);
            _serviceService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIDService(int id)
        {
            var values = _serviceService.TGetByID(id);
            return Ok(values);
        }
    }
}

