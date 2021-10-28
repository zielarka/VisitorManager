using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Core.Domain
{
    public class Device : Entity
    {
        public string SerialNumber { get; protected set; }
        public string Name { get; protected set; }
        public Guid? StoreId { get; protected set; }
        public DateTime LastActive { get; protected set; }
        public DateTime CreatedAt { get; protected set; }


        protected Device()
        {
        }
        public Device(Guid id, string serialNumber, string name, Guid? storeId)
        {
            Id = id;
            SerialNumber = serialNumber;
            Name = name;
            SetStoreId(storeId);
            LastActive = DateTime.Now;
            CreatedAt =DateTime.Now;
        }

        public void SetStoreId(Guid? storeId)
        {
            StoreId = storeId;
        }

    }
}
