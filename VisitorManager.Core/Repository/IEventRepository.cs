using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Response.Event;

namespace VisitorManager.Core.Repository
{
    public interface IEventRepository :IRepositoryMarker
    {
        CountsPerDay  SumCountsInDay(Guid deviceId, DateTime day);
        Task<EventResponse> AddAsync(Event @event);

    }
}
