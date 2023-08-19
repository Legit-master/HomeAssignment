using LegitSecurity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegitSecurity.Actions
{
    /// <summary>
    /// interface for all actions to implement.
    /// </summary>
    public interface IAction
    {
        // Determine the eventType, we could change this to a list in order to perfrom this action on several eventTypes
        string EventType { get; }

        //return true/false whether the event anomality behaviour occured.
        bool CheckAnomality(IEvent eventData);
        
        // What action to take if checkAnomality returns true.
        // I know in our case this shouldnt be awaited
        // but this is to represent that performing actions take time and how to handle it.
        Task PerformActionAsync();
    }
}
