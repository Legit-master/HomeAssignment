using LegitSecurity.Events.EventPoco;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegitSecurity.Events
{
    /// <summary>
    /// Create a new event every time an event raises using Factory design pattern.
    /// here we determine which event we are dealing with, parsing it and returning it for further handling
    /// </summary>
    public class EventFactory
    {
        public IEvent? CreateEvent(string eventDataJson)
        {
            if (string.IsNullOrEmpty(eventDataJson))
            {
                throw new ArgumentException("Event data JSON is null or empty.");
            }
            try
            {
                var eventDataObject = JObject.Parse(eventDataJson);

                string eventType = DetermineEventType(eventDataObject);

                // based on the eventType parse and return the correct event object
                switch (eventType)
                {
                    case ConstStrings.PushEvent:
                        PushEvent? pushEvent = JsonConvert.DeserializeObject<PushEvent>(eventDataJson);
                        return pushEvent;
                    case ConstStrings.RepoEvent:
                        RepoEvent? repoEvent = JsonConvert.DeserializeObject<RepoEvent>(eventDataJson);
                        return repoEvent;
                    case ConstStrings.TeamEvent:
                        TeamEvent? teamEvent = JsonConvert.DeserializeObject<TeamEvent>(eventDataJson);
                        return teamEvent;
                    default:
                        // throw unkown event exception and log it for inspection.
                        throw new NotSupportedException($"Event type '{eventType}' is not supported.");
                }
            }
            catch (JsonException jsonexception)
            {
                throw new ArgumentException($"error parsing the json file {eventDataJson}", jsonexception);
            }
            catch (Exception ex) 
            {
                throw new Exception("unkown exception",ex);
            }
        }

        /// <summary>
        /// determing which event has entered.
        /// </summary>
        /// <param name="eventDataObject"> the json recieved from the webhook.</param>
        /// <returns>return the correct event.</returns>
        private string DetermineEventType(JObject eventDataObject)
        {
            bool hasActionCreated = eventDataObject.ContainsKey("action") && eventDataObject["action"]?.ToString() == "created";

            if (eventDataObject.ContainsKey("pusher"))
            {
                return ConstStrings.PushEvent;
            }

            else if (eventDataObject.ContainsKey("team") && eventDataObject.ContainsKey("action") && eventDataObject["action"]?.ToString() == "created")
            {
                    return ConstStrings.TeamEvent;
              
            }
            else if (eventDataObject.ContainsKey("repository") && (eventDataObject.ContainsKey("action") && eventDataObject["action"]?.ToString()=="deleted"))
            {
                    return ConstStrings.RepoEvent;
            }
             
            return ConstStrings.UnkownEvent;
            
        }

    }
}

