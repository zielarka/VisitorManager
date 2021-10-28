/// <summary>
///  Marker to enter the salon.
///  Event states can be described in the database. 
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Core.Config
{
    public class StateCounterIdOptions
    {
        public int idCounterIn { get; set; } 
        public int idCounterOut { get; set; } 
        public int idCounterRight { get; set; }
        public int idCounterLeft { get; set; } 
    }
}
