using System.Text;
using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.EventBusResult;
using Microservices.EventBus.Orchestrator.EventPublisher.Interface;
using Microservices.EventBus.RabbitMQ;
using Microservices.EventBus.RabbitMQ.Models;
using Newtonsoft.Json;
using RabbitMQConstants = Microservices.EventBus.Orchestrator.Constant.RabbitMQConstants;

namespace Microservices.EventBus.Orchestrator.EventPublisher.Implementation;

public class RabbitMQEventPublisher : IEventPublisher
{
    private readonly RabbitMQPublishManager _rabbitMqPublishManager;

    public RabbitMQEventPublisher(RabbitMQPublishManager rabbitMqPublishManager)
    {
        _rabbitMqPublishManager = rabbitMqPublishManager;
    }


    public void PublishIdentityEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        string routeKey = RabbitMQConstants.IdentityQueueRouteKey + @event.GetEventName();
        var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        PublishMessageInput input = new()
        {
            ExchangeName = RabbitMQConstants.ExchangeName,
            RouteKey = routeKey,
            Message = message
        };

        var result = _rabbitMqPublishManager.PublishMessage(input);

        if (!result.IsSuccess)
        {
            //Event did not published. Can save to db and trigger by hangfire
        }
    }

    public void PublishUserEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        string routeKey = RabbitMQConstants.UserQueueRouteKey + @event.GetEventName();
        var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        PublishMessageInput input = new()
        {
            ExchangeName = RabbitMQConstants.ExchangeName,
            RouteKey = routeKey,
            Message = message
        };

        var result = _rabbitMqPublishManager.PublishMessage(input);

        if (!result.IsSuccess)
        {
            //Event did not published. Can save to db and trigger by hangfire
        }
    }

    public void PublishNotificationEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        string routeKey = RabbitMQConstants.NotificationQueueRouteKey + @event.GetEventName();
        var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        PublishMessageInput input = new()
        {
            ExchangeName = RabbitMQConstants.ExchangeName,
            RouteKey = routeKey,
            Message = message
        };

        var result = _rabbitMqPublishManager.PublishMessage(input);

        if (!result.IsSuccess)
        {
            //Event did not published. Can save to db and trigger by hangfire
        }
    }

    public void PublishChatEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        string routeKey = RabbitMQConstants.ChatQueueRouteKey + @event.GetEventName();
        var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        PublishMessageInput input = new()
        {
            ExchangeName = RabbitMQConstants.ExchangeName,
            RouteKey = routeKey,
            Message = message
        };

        var result = _rabbitMqPublishManager.PublishMessage(input);

        if (!result.IsSuccess)
        {
            //Event did not published. Can save to db and trigger by hangfire
        }
    }

    public void PublishFavoriteEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        string routeKey = RabbitMQConstants.FavoriteQueueRouteKey + @event.GetEventName();
        var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        PublishMessageInput input = new()
        {
            ExchangeName = RabbitMQConstants.ExchangeName,
            RouteKey = routeKey,
            Message = message
        };

        var result = _rabbitMqPublishManager.PublishMessage(input);

        if (!result.IsSuccess)
        {
            //Event did not published. Can save to db and trigger by hangfire
        }
    }

    public void PublishArticleEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        string routeKey = RabbitMQConstants.ArticleQueueRouteKey + @event.GetEventName();
        var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        PublishMessageInput input = new()
        {
            ExchangeName = RabbitMQConstants.ExchangeName,
            RouteKey = routeKey,
            Message = message
        };

        var result = _rabbitMqPublishManager.PublishMessage(input);

        if (!result.IsSuccess)
        {
            //Event did not published. Can save to db and trigger by hangfire
        }
    }

    public void PublishForumEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        string routeKey = RabbitMQConstants.ForumQueueRouteKey + @event.GetEventName();
        var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        PublishMessageInput input = new()
        {
            ExchangeName = RabbitMQConstants.ExchangeName,
            RouteKey = routeKey,
            Message = message
        };

        var result = _rabbitMqPublishManager.PublishMessage(input);

        if (!result.IsSuccess)
        {
            //Event did not published. Can save to db and trigger by hangfire
        }
    }
}