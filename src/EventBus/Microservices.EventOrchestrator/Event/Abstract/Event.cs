namespace Microservices.EventOrchestrator.Event.Abstract
{
    public abstract class Event<TEventInfo> : IEvent<TEventInfo>
    {
        public TEventInfo EventInfo { get; }

        public Event(TEventInfo eventInfo)
        {
            this.EventInfo = eventInfo;
        }
    }
}
