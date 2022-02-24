using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.EventBusResult;
using Microservices.EventBus.Orchestrator.EventPublisher.Interface;
using Microservices.EventBus.RabbitMQ;

namespace Microservices.EventBus.Orchestrator.EventPublisher.Implementation;

public class RabbitMQEventPublisher : IEventPublisher
{
    private readonly RabbitMQPublishManager _rabbitMqPublishManager;

    public RabbitMQEventPublisher(RabbitMQPublishManager rabbitMqPublishManager)
    {
        _rabbitMqPublishManager = rabbitMqPublishManager;
    }

    public IEventBusResult PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        throw new NotImplementedException();
    }
}