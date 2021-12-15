using Microservices.EventOrchestrator.EventBusResult;

namespace Microservices.EventOrchestrator.EventPublisher.Abstract
{
    public interface IEventPublisher : IDisposable
    {
        IEventBusResult PublishIdentityEvent<TEvent>(string messageName, TEvent @event);
        IEventBusResult PublishUserEvent<TEvent>(string messageName, TEvent @event);
        IEventBusResult PublishChatEvent<TEvent>(string messageName, TEvent @event);
        IEventBusResult PublishNotificationEvent<TEvent>(string messageName, TEvent @event);
        IEventBusResult PublishArticleEvent<TEvent>(string messageName, TEvent @event);
        IEventBusResult PublishForumEvent<TEvent>(string messageName, TEvent @event);
        IEventBusResult PublishFavoriteEvent<TEvent>(string messageName, TEvent @event);
    }
}
