using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.CustomerDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListCustomer()
        {
            var values = _customerService.TGetList();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerAddDto customerAddDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Customer>(customerAddDto);
            await _customerService.TInsertAsync(values);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateDto customerUpdateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Customer>(customerUpdateDto);
            await _customerService.TUpdateAsync(values);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var values = _customerService.TGetByID(id);
            _customerService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIDCustomer(int id)
        {
            var values = _customerService.TGetByID(id);
            return Ok(values);
        }
    }
}

