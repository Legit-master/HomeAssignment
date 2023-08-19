# HomeAssignment

Hi,
thanks for taking the time to look through my work.
I enjoyed doing this exercise :)

# setup and run
The project is written in c#.

To set up the project I used ngrok, but it does not give you a permanent address
or of course if you have a static address that's preferred.

Go to Runner class -> Main, and change port and prefix (your address) to what ever you like.

Then run the program.

Every new event that comes will perform an action based on predefined rules.

# more on the project
The project uses several design patterns such as strategy, observer and factory and follows best object-oriented practices.
It is easy to maintain and is expandable.

There are comments through the project, but here is a quick overview of how things work.
Events are collected through a listener and processed by an EventFactory, which identifies the event and returns 
a new object based on the event type.
An Action Manger class handles all actions that must be performed when an event was received.
Beforehand, each action registers the events it wants to be triggered on.
Then, when an event is identified, the action manager goes over all relevant actions for this events,
checks whether an action should be taken and performs an action if needed.

# That's it. Thanks, Yotam.
