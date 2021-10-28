using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManager.Infrastructure.Commands.Store;
using VisitorManager.Infrastructure.Services;

namespace ApiVisitorManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var stores = await _storeService.BrowserAsync(name);
            return Json(stores);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStore command)
        {
            command.id = Guid.NewGuid();
            await _storeService.CreateAsync(command.id, command.name, command.city, command.street, command.sid, command.postalCode, command.responsiblePerson, command.latitude, command.longitude);
            return Created($"store/{command.id}", null);
        }

        [HttpPut("{storeId}")]
        public async Task<IActionResult> Put(Guid storeId,[FromBody] UpdateStore updateStore)
        {
            await _storeService.UpdateAsync(storeId, updateStore.name);
            return NoContent();
        }

        [HttpDelete("{storeId}")]
        public async Task<IActionResult> Delete(Guid storeId)
        {
            await _storeService.DeleteAsync(storeId);
            return NoContent();
        }
    }
}