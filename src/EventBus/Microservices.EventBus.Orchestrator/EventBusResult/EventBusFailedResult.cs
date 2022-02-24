namespace Microservices.EventBus.Orchestrator.EventBusResult;

public class EventBusFailedResult : EventBusResultBase
{
    public EventBusFailedResult():base(false)
    {

    }


    public EventBusFailedResult(string message):base(false,message)
    {

    }
}