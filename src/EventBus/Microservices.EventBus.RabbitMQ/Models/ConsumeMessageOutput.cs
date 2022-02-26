namespace Microservices.EventBus.RabbitMQ.Models;

public class ConsumeMessageOutput
{
    public bool IsSuccess { get; set; }
    public string ResultMessage { get; set; }
}