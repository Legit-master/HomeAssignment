using LegitSecurity.Actions;
using LegitSecurity.Actions.PushActions;
using LegitSecurity.Actions.RepoActions;
using LegitSecurity.Actions.TeamActions;
using LegitSecurity.Events;
using LegitSecurity.WebHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegitSecurity
{
    //this is the main entry point of the app.
    public class Runner
    {
        public static async Task Main(string[] args) 
        {
            //init 
            Listener listener = new();
            EventFactory eventFactory = new();
            
            //here we add all actions we want to perform, in real life i would use dependency injection.
            ActionManger actionManager = new();
            actionManager.AddAction(new TimeAnomality());
            actionManager.AddAction(new CreateDeleteTimeInterval());
            actionManager.AddAction(new TeamCreateNameAnomality());

            //run forever to capture all events.
            while (true) 
            {
                var newEvent = Listener.Start();
                try
                {
                    //when an event comes in, create an object out of it using event factory
                    var newEventObj = eventFactory.CreateEvent(newEvent);
                    if (newEventObj != null ) 
                    {
                        //proccess and handle event
                        // we want this to be async so we can free the main thread to handle other events 
                        //in case proccessing events takes time.
                        await Task.Run(() => actionManager.ProcessEventAsync(newEventObj));
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex);
                }
            }   
        }
    }
}
