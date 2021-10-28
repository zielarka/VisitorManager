using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Infrastructure.Commands.Store
{
    public class CreateStore
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string sid { get; set; }
        public string postalCode { get; set; }
        public string responsiblePerson { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}
