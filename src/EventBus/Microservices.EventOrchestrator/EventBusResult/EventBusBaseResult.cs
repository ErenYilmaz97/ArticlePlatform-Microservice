namespace Microservices.EventOrchestrator.EventBusResult
{
    public class EventBusBaseResult : IEventBusResult
    {
        public bool Succeed { get; set; }
        public string ResultMessage { get; set; }


        public EventBusBaseResult(bool succeed)
        {
            this.Succeed = succeed;
        }

        public EventBusBaseResult(bool succeed, string message):this(succeed)
        {
            this.ResultMessage = message;
        }
    }
}
