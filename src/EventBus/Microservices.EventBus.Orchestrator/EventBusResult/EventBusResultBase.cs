namespace Microservices.EventBus.Orchestrator.EventBusResult;

public class EventBusResultBase : IEventBusResult
{
    public bool Succeed { get; set; }
    public string ResultMessage { get; set; }


    public EventBusResultBase(bool succeed)
    {
        this.Succeed = succeed;
    }

    public EventBusResultBase(bool succeed, string message):this(succeed)
    {
        this.ResultMessage = message;
    }
}