namespace SpaceTransport.Scripts.EventSystem
{
    public abstract class Event
    {
        public string Description;
    }

    public abstract class RouteEvent : Event
    {
        public Route Route;
    }

    public class RouteCompletedEvent : RouteEvent
    { 
    }

    public class DebugEvent : Event
    {
        public int VerbosityLevel;
    }

    public class NextTurnEvent : Event
    {

    }

    public class RouteCreatedEvent : RouteEvent
    {
    }

}
