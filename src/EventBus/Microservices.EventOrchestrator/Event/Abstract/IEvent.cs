using Microservices.EventOrchestrator.EventInfoObject.Abstract;

namespace Microservices.EventOrchestrator.Event.Abstract
{
    public interface IEvent<TEventInfo>
    {
        public TEventInfo EventInfo { get; }
    }
}
