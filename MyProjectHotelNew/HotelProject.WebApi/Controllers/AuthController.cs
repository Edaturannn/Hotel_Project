using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.AuthRepository;
using HotelProject.DataAccessLayer.ServiceResponse;
using HotelProject.DtoLayer.Dtos.UserDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisteDto request)
        {
            var response = await _authRepository.Register(
            new User { Username = request.Username}, request.Password
        );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("Login")]

        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)

        {
            var response = await _authRepository.Login(
            request.Username, request.Password
         );

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}

