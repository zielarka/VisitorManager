using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Core.Domain
{
    public class Event : Entity
    {
        public Guid DeviceId { get; protected set; }
        public DateTime Date { get; protected set; }
        public int CounterId { get; protected set; }
        public long Amount { get; protected set; }

        protected Event()
        {
        }
        public Event(Guid id, Guid deviceId, DateTime date, int counterId, long amount)
        {
            Id = id;
            DeviceId = deviceId;
            Date = date;
            CounterId = counterId;
            Amount = amount;
        }

    }
}
