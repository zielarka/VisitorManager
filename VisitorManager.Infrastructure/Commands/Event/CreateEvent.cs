using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Infrastructure.Commands.Event
{
    public class CreateEvent
    {
        public Guid id { get; set; }
        public Guid deviceId { get; set; }
        public int counterId { get; set; }
        public long amount { get; set; }
        public DateTime dateTime { get; set; }
    }
}
