using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Core.Response.Event;
using VisitorManager.Infrastructure.Commands.Event;

namespace VisitorManager.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventResponse> AddAsync(CreateEvent createEvent)
        {
            var events = new Event(createEvent.id, createEvent.deviceId,createEvent.dateTime, createEvent.counterId, createEvent.amount);
            return await _eventRepository.AddAsync(events);
        }
    }
}
