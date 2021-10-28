using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Config;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Core.Response.Event;
using VisitorManager.Persistence.Migrations;

namespace VisitorManager.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext_Sqlite _context;
        private readonly IOptions<StateCounterIdOptions> _appsettings;

        public EventRepository(DataContext_Sqlite context, IOptions<StateCounterIdOptions> appsettings)
        {
            _context = context;
            _appsettings = appsettings;
        }

        public  CountsPerDay SumCountsInDay(Guid deviceId,DateTime day )
        {
            int[] CounterIdState = new int[] 
            { 
                _appsettings.Value.idCounterIn, 
                _appsettings.Value.idCounterOut 
            };
            var statisticsAggregater = new CountsPerDay();
            DateTime startDate = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime endDate = new DateTime(day.Year, day.Month, day.Day, 23, 59, 59);
            long sumCounts = _context.Event.Where(x => x.DeviceId == deviceId && x.Date >= startDate && x.Date <= endDate  && CounterIdState.Contains(x.CounterId)).Sum(y =>y.Amount);
            return statisticsAggregater = new CountsPerDay()
            {
                count = Convert.ToInt32(sumCounts),
                date = startDate.ToString("yyyy-MM-dd")
            };
        }

        public async Task<EventResponse> AddAsync(Event events)
        {
            var response = new EventResponse();
            try
            {
                await _context.Event.AddAsync(events);
                await _context.SaveChangesAsync();
                response = new EventResponse()
                {
                    success = await Task.FromResult(true),
                    errorMessage = ""
                };
            }
            catch (Exception e)
            {
                response = new EventResponse()
                {
                    success = false,
                    errorMessage = e.ToString()
                };
            }
            return response;
        }

    }
}
