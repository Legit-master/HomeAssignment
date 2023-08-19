using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegitSecurity.Events
{
    /// <summary>
    /// interface for all events.
    /// </summary>
    public interface IEvent
    {
        public string EventType { get; }
    }
}
