using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Infrastructure.Commands.Device
{
    public class CreateDevice
    {
        public Guid id { get; set; }
        public string serialNumber { get; set; }
        public string name { get; set; }
        public Guid? storeId { get; set; }
    }
}
