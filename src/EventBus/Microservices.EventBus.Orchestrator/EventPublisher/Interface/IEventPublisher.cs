using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.EventBusResult;

namespace Microservices.EventBus.Orchestrator.EventPublisher.Interface;

public interface IEventPublisher
{
    public IEventBusResult PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent;
}