using RabbitMQ.Client.Events;

namespace Microservices.EventBus.RabbitMQ.Models;

public class ConsumeMessageInput
{
    public string QueueName { get; set; }
    public Action<object, BasicDeliverEventArgs> ConsumerMethot { get; set; }
}