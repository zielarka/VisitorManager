using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Response.Event;
using VisitorManager.Infrastructure.Commands.Event;

namespace VisitorManager.Infrastructure.Services
{
    public interface IEventService :IServiceMarker
    {
        Task<EventResponse> AddAsync(CreateEvent createEvent);
    }
}
