using System.Text;
using Microservices.EventBus.Orchestrator.Event.Chat;
using Microservices.EventBus.Orchestrator.Event.Identity;
using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.Event.Notification;
using Microservices.EventBus.Orchestrator.Event.User;
using Microservices.EventBus.RabbitMQ;
using Microservices.EventBus.Orchestrator.EventOrchestrator;
using Microservices.EventBus.RabbitMQ.Models;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQConstants = Microservices.EventBus.Orchestrator.Constant.RabbitMQConstants;

namespace Microservices.EventBus.Orchestrator.OrchestratorConsumer;

public class OrchestratorConsumer : BackgroundService
{
    private readonly RabbitMQConsumeManager _rabbitMqConsumeManager;
    private readonly EventOrchestrator.EventOrchestrator _eventOrchestrator;

    public OrchestratorConsumer(RabbitMQConsumeManager rabbitMqConsumeManager, 
                                EventOrchestrator.EventOrchestrator eventOrchestrator)
    {
        _rabbitMqConsumeManager = rabbitMqConsumeManager;
        _eventOrchestrator = eventOrchestrator;
    }
    
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        ConsumeMessageInput input = new()
        {
            QueueName = RabbitMQConstants.OrchestratorQueueName,
            ConsumerMethot = ConsumeOrchestratorEvent
        };

        var result = _rabbitMqConsumeManager.ConsumeMessage(input);
        return Task.CompletedTask;
    }


    private async void ConsumeOrchestratorEvent(object sender, BasicDeliverEventArgs args)
    {
        string eventName = args.RoutingKey.Split(".").Last();
        string message = Encoding.UTF8.GetString(args.Body.ToArray());
        IEvent @event = DeserializeEvent(eventName, message);

        var result = await _eventOrchestrator.HandleEvent(@event);

        if (result.Succeed)
        {
            //Event handled. Remove from queue
            _rabbitMqConsumeManager.RemoveMessageFromQueue(args.DeliveryTag);
        }
    }


    private IEvent DeserializeEvent(string eventName, string @event)
    {
        return eventName switch
        {
            "IdentityTestEvent" => JsonConvert.DeserializeObject<IdentityTestEvent>(@event),
            "UserTestEvent" => JsonConvert.DeserializeObject<UserTestEvent>(@event),
            "NotificationTestEvent" => JsonConvert.DeserializeObject<NotificationTestEvent>(@event),
            "ChatTestEvent" => JsonConvert.DeserializeObject<ChatTestEvent>(@event),
        };
    }
    
}