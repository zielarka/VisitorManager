using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManager.Infrastructure.Commands.Device;
using VisitorManager.Infrastructure.Services;

namespace ApiVisitorManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var devices = await _deviceService.BrowserAsync(name);
            return Json(devices);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDevice command)
        {
            command.id = Guid.NewGuid();
            command.storeId = null;
            await _deviceService.CreateAsync(command.id, command.serialNumber, command.name, command.storeId);
            return Created($"store/{command.id}", null);
        }

        [HttpPut("{deviceId}")]
        public async Task<IActionResult> Put(Guid deviceId, [FromBody] UpdateDevice updateStore)
        {
            await _deviceService.UpdateAsync(deviceId, updateStore.storeId);
            return NoContent();
        }

        [HttpDelete("{deviceId}")]
        public async Task<IActionResult> Delete(Guid deviceId)
        {
            await _deviceService.DeleteAsync(deviceId);
            return NoContent();
        }
    }
}
