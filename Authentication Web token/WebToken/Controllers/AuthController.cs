using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebToken.CustomModel;
using WebToken.Data;
using WebToken.Model;
using WebToken.Services;

namespace WebToken.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserCustomModel request)
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new User { UserName = request.Username },
            request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserCustomModel request)
        {
            ServiceResponse<string> response = await _authRepo.Login(request.Username,request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
