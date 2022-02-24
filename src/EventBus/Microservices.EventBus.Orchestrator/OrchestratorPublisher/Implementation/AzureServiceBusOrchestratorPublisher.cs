using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.OrchestratorPublisher.Interface;

namespace Microservices.EventBus.Orchestrator.OrchestratorPublisher.Implementation;

public class AzureServiceBusOrchestratorPublisher : IOrchestratorPublisher
{
    private readonly AzureServiceBusOrchestratorPublisher _publisher;

    public AzureServiceBusOrchestratorPublisher(AzureServiceBusOrchestratorPublisher publisher)
    {
        _publisher = publisher;
    }

    public void PublishToOrchestrator<TEvent>(TEvent @event) where TEvent : class, IEvent
    {
        throw new NotImplementedException();
    }
}