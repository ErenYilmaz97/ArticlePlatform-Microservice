namespace Microservices.EventBus.RabbitMQ.Models;

public class PublishMessageInput
{
    public string ExchangeName { get; set; }
    public string RouteKey { get; set; }
    public byte[] Message { get; set; }
}