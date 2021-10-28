using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManager.Infrastructure.Commands.Event;
using VisitorManager.Infrastructure.Commands.Statistics;
using VisitorManager.Infrastructure.Services;

namespace ApiVisitorManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IStatisticsService _statisticsService;
        public EventController(IEventService eventService, IStatisticsService statisticsService)
        {
            _eventService = eventService;
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatisticsperDay([FromQuery] GetAggregateCount getAggregateCount)
        {
            var result = await _statisticsService.BrowserAsync(getAggregateCount);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] CreateEvent command)
        {
            command.id = Guid.NewGuid();
            var events =await _eventService.AddAsync(command);
            return Json(events);
        }
    }
}
