using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.TestimonialDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService testimonialService,IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListTestimonial()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialAddDto testimonialAddDto)
        {
            if(!ModelState.IsValid)//Ekleme başarısız olunca bu kod satırı çalışır...
            {
                return BadRequest();
            }
            var values = _mapper.Map<Testimonial>(testimonialAddDto);
            await _testimonialService.TInsertAsync(values);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(TestimonialUpdateDto testimonialUpdateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Testimonial>(testimonialUpdateDto);
            await _testimonialService.TUpdateAsync(values);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }
    }
}

