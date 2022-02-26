using System.Text;
using System.Text.Json.Serialization;
using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.OrchestratorPublisher.Interface;
using Microservices.EventBus.RabbitMQ;
using Microservices.EventBus.RabbitMQ.Models;
using Newtonsoft.Json;
using RabbitMQConstants = Microservices.EventBus.Orchestrator.Constant.RabbitMQConstants;

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
        string routeKey = RabbitMQConstants.OrchestratorQueueRouteKey + @event.GetEventName();
        var serializedEvent = JsonConvert.SerializeObject(@event);

        PublishMessageInput input = new()
        {
            ExchangeName = RabbitMQConstants.ExchangeName,
            RouteKey = routeKey,
            Message = Encoding.UTF8.GetBytes(serializedEvent)
        };

        var result = _rabbitMqPublishManager.PublishMessage(input);

        if (!result.IsSuccess)
        {
            //Event did not published. 
            //Add to Database and try again with hangfire
        }

    }
}