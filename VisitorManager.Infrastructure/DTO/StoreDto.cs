using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Infrastructure.DTO
{
    public class StoreDto
    {
        public Guid id { get; set; }
        public string name { get;  set; }
        public string city { get;  set; }
        public string street { get;  set; }
        public string sid { get;  set; }
    }
}
