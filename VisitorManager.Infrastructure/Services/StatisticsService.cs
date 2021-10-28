using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Infrastructure.Commands.Statistics;
using VisitorManager.Infrastructure.DTO;

namespace VisitorManager.Infrastructure.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IDeviceRepository _deviceRepository;

        public StatisticsService(IEventRepository eventRepository, IDeviceRepository deviceRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task<IEnumerable<CountsPerDay>> BrowserAsync(GetAggregateCount command)
        {
            var liststatisticsAggregaterDto = new List<CountsPerDay>();
            var device = await _deviceRepository.GetAsyncStoreId(command.storeId);
            if (device == null)
            {
                throw new Exception($"Device named: '{command.storeId}' not exists");
            }

            for (var day = command.startDate; day <= command.endDate; day = day.AddDays(1))
            {
                liststatisticsAggregaterDto.Add(_eventRepository.SumCountsInDay(device.Id, day));
            }

            return liststatisticsAggregaterDto;
        }
    }
}
