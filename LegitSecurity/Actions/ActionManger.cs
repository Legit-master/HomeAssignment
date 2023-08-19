using LegitSecurity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegitSecurity.Actions
{
    /// <summary>
    /// Action Manager handles all actions. this is baesd on observer pattern.
    /// </summary>
    public class ActionManger
    {
        // a Dictionary that hold all action based on thier type.
        private Dictionary<string, List<IAction>> eventTypeToActions;
        public ActionManger()
        {
            eventTypeToActions = new Dictionary<string, List<IAction>>();
        }

        /// <summary>
        /// add Action to perform on certain events.
        /// </summary>
        /// <param name="action"></param>
        public void AddAction(IAction action)
        {
            string eventType = action.EventType;

            if (!eventTypeToActions.ContainsKey(eventType))
            {
                eventTypeToActions[eventType] = new List<IAction>();
            }

            eventTypeToActions[eventType].Add(action);
        }

        /// <summary>
        /// based on eventType, check i an anomality occured and perfrom action accordigly 
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>

        public async Task ProcessEventAsync(IEvent eventData)
        {
            string eventType = eventData.EventType;

            if (eventTypeToActions.ContainsKey(eventType))
            {
                foreach (var action in eventTypeToActions[eventType])
                {
                    if (action.CheckAnomality(eventData))
                    {
                         await action.PerformActionAsync();
                    }
                }
            }
        }
    }
}
