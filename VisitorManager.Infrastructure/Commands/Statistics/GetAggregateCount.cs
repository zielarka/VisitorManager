using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Infrastructure.Commands.Statistics
{
    public class GetAggregateCount
    {
        public Guid storeId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

    }
}
