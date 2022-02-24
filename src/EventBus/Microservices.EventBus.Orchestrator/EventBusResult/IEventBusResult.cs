namespace Microservices.EventBus.Orchestrator.EventBusResult;

public interface IEventBusResult
{
    bool Succeed { get; set; }
    string ResultMessage { get; set; }
}