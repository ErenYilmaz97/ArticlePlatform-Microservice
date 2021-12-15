using Microservices.EventOrchestrator.Enum;
using Microservices.EventOrchestrator.OrchestratorEvent.Abstract;

namespace Microservices.EventOrchestrator.EventOrchestratorPublisher
{
    public interface IEventOrchestratorPublisher
    {
        public void PublishOrchestratorEvent<TOrchestratorEvent>(OrchestratorEventType eventType, TOrchestratorEvent @event) where TOrchestratorEvent : class, IOrchestratorEvent;
    }
}
