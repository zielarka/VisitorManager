using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Core.Response.Event
{
    public class EventResponse
    {
        public bool success { get; set; }
        public string errorMessage { get; set; }
    }
}
