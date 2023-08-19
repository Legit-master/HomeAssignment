using LegitSecurity.Events;
using LegitSecurity.Events.EventPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegitSecurity.Actions.TeamActions
{
    /// <summary>
    /// Action to check whether a team was created with the prefix hacker
    /// </summary>
    public class TeamCreateNameAnomality : IAction
    {
        public string EventType => "TeamEvent";

        public bool CheckAnomality(IEvent eventData)
        {
            return ((TeamEvent)eventData).team.name.StartsWith("hacker");
        }

        //inherit doc
        public async Task PerformActionAsync()
        {
            Console.WriteLine("A team was created with the prefix hacker!");
        }
    }
}
