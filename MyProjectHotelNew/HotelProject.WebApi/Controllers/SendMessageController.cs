using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.SendMessageDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SendMessageController : Controller
    {
        private readonly ISendMessageService _sendMessageService;
        private readonly IMapper _mapper;
        public SendMessageController(ISendMessageService sendMessageService, IMapper mapper)
        {
            _sendMessageService = sendMessageService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListSendMessage()
        {
            var values = _sendMessageService.TGetList();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(SendMessageAddDto sendMessageAddDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<SendMessage>(sendMessageAddDto);
            await _sendMessageService.TInsertAsync(values);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateSendMessage(SendMessageUpdateDto sendMessageUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<SendMessage>(sendMessageUpdateDto);
            await _sendMessageService.TUpdateAsync(values);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var values = _sendMessageService.TGetByID(id);
            _sendMessageService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIDSendMessage(int id)
        {
            var values = _sendMessageService.TGetByID(id);
            return Ok(values);
        }
    }
}

