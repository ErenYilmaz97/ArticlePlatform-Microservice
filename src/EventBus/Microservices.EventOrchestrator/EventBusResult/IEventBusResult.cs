namespace Microservices.EventOrchestrator.EventBusResult
{
    public interface IEventBusResult
    {
        public bool Succeed { get; set; }
        public string ResultMessage { get; set; }
    }
}
