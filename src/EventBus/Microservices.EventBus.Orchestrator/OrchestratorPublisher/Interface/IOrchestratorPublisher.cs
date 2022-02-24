using Microservices.EventBus.Orchestrator.Event.Interface;

namespace Microservices.EventBus.Orchestrator.OrchestratorPublisher.Interface;

public interface IOrchestratorPublisher
{
    void PublishToOrchestrator<TEvent>(TEvent @event) where TEvent: class, IEvent; 
}