using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Infrastructure.DTO
{
    public class DeviceDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public Guid storeId { get; set; }
    }
}
