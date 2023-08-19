using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegitSecurity.Events.EventPoco.Common;

namespace LegitSecurity.Events.EventPoco
{
    /// <summary>
    /// poco Team WebHook event
    /// </summary>
    public class TeamEvent : IEvent
    {
        public string EventType => ConstStrings.TeamEvent;
        public string action { get; set; }
        public Team? team { get; set; }
        public Organization? organization { get; set; }
        public Sender? sender { get; set; }
    }
    public class Team
    {
        public string name { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public string privacy { get; set; }
        public string notification_setting { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string members_url { get; set; }
        public string repositories_url { get; set; }
        public string permission { get; set; }
        public object parent { get; set; }
    }
}
