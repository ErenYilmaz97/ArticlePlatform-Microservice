using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.OrchestratorPublisher.Interface;
using Microservices.EventBus.RabbitMQ;

namespace Microservices.EventBus.Orchestrator.OrchestratorPublisher.Implementation;

public class RabbitMQOrchestratorPublisher : IOrchestratorPublisher
{
    private readonly RabbitMQPublishManager _rabbitMqPublishManager;

    public RabbitMQOrchestratorPublisher(RabbitMQPublishManager rabbitMqPublishManager)
    {
        _rabbitMqPublishManager = rabbitMqPublishManager;
    }

    public void PublishToOrchestrator<TEvent>(TEvent @event) where TEvent : class, IEvent
    {
        //Publish event to orchestrator queue via rabbitmq
    }
}