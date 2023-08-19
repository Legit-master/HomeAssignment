using LegitSecurity.Events;
using LegitSecurity.Events.EventPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegitSecurity.Actions.RepoActions
{
    /// <summary>
    /// Action to check whether a repo was created and then deleted less than two hours
    /// </summary>
    public class CreateDeleteTimeInterval : IAction
    {
        public string EventType => "RepoEvent";
        public bool CheckAnomality(IEvent eventData)
        {
            var curEvent = (RepoEvent)eventData;
            if (eventData == null) return false;
            else if (curEvent.action == "deleted") 
            { 
                var lastUpdateTime= curEvent.repository.updated_at;
                if (lastUpdateTime- curEvent.repository.created_at <= TimeSpan.FromHours(2)) 
                {
                    return true;
                }
            }
            return false;
        }

        //inherit doc
        public async Task PerformActionAsync()
        {
            Console.WriteLine("repository was dleted less than two hours from creation");
        }

    }
}
