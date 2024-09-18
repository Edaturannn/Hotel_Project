using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.ServiceDtos;
using HotelProject.DtoLayer.Dtos.StaffDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{ 
    [Route("api/[controller]")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;
        public StaffController(IStaffService staffService ,IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListStaff()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffAddDto staffAddDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Staff>(staffAddDto);
            await _staffService.TInsertAsync(values);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateStaff(StaffUpdateDto staffUpdateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Staff>(staffUpdateDto);
            await _staffService.TUpdateAsync(values);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetByID(id);
            _staffService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIDStaff(int id)
        {
            var values = _staffService.TGetByID(id);
            return Ok(values);
        }
    }
}

