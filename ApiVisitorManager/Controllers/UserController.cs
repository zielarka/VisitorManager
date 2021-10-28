using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManager.Infrastructure.Services;

namespace ApiVisitorManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var users = await _userService.BrowserAsync(name);
            return Json(users);
        }

        //[HttpDelete("{userId}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid userId)
        {
            await _userService.DeleteAsync(userId);
            return NoContent();
        }
    }
}
