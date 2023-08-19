using LegitSecurity.Events;
using LegitSecurity.Events.EventPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegitSecurity.Actions.PushActions
{
    /// <summary>
    /// Action to check whether a push occured between 2 pm and 4 pm
    /// </summary>
    public class TimeAnomality : IAction
    {
        public string EventType => ConstStrings.PushEvent;

        public bool CheckAnomality(IEvent eventData)
        {
            DateTime eventTime = ((PushEvent)eventData).head_commit.timestamp;
            if (eventTime.Hour >= 14 && eventTime.Hour <= 16)
            {
                return true;
            }
            return false;   
        }
        //inherit doc
        public async Task PerformActionAsync()
        {
            Console.WriteLine($"someone pushed between 14-16 eventId");
        }
    }
}
