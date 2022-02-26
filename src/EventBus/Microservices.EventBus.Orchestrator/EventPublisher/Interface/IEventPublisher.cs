using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.EventBusResult;

namespace Microservices.EventBus.Orchestrator.EventPublisher.Interface;

public interface IEventPublisher
{
    void PublishIdentityEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    void PublishUserEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    void PublishNotificationEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    void PublishChatEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    void PublishFavoriteEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    void PublishArticleEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    void PublishForumEvent<TEvent>(TEvent @event) where TEvent : IEvent;
}