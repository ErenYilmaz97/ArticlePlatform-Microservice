namespace Microservices.EventBus.Orchestrator.EventBusResult;

public class EventBusSuccessResult : EventBusResultBase
{
    public EventBusSuccessResult():base(true)
    {

    }


    public EventBusSuccessResult(string message):base(true,message)
    {

    }
}