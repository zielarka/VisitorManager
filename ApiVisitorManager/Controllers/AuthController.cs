using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManager.Infrastructure.Commands.User;
using VisitorManager.Infrastructure.Services;

namespace ApiVisitorManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            var @user = await _authService.Login(loginUser.userName.ToLower(), loginUser.password);
            return Ok(new { @user.token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUser createUser)
        {
            createUser.id = Guid.NewGuid();
            await _authService.Register(createUser.id,createUser.userName,createUser.password);
            return Created($"auth/{createUser.id}", null);
        }

        [AllowAnonymous]
        [Route("/Error/{code:int?}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? code)
        {
            ViewBag.Code = code.GetValueOrDefault(500);
            return View();
        }

    }
}
