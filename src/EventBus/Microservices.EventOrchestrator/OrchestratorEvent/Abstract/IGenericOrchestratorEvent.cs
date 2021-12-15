using MediatR;
using Microservices.EventOrchestrator.Event.Abstract;
using Microservices.EventOrchestrator.EventBusResult;
using Microservices.EventOrchestrator.EventInfoObject.Abstract;

namespace Microservices.EventOrchestrator.OrchestratorEvent.Abstract
{
    
    public interface IGenericOrchestratorEvent<TEvent,TEventInfo> : IOrchestratorEvent
           where TEvent: class, IEvent<TEventInfo>
           where TEventInfo: class, IEventInfoObject<TEvent>
    {
        public TEventInfo EventInfo { get; set; }
    }
}
