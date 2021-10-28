using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Infrastructure.Commands.Statistics;
using VisitorManager.Infrastructure.DTO;

namespace VisitorManager.Infrastructure.Services
{
    public interface IStatisticsService: IServiceMarker
    {
        Task<IEnumerable<CountsPerDay>> BrowserAsync(GetAggregateCount command);
    }
}
