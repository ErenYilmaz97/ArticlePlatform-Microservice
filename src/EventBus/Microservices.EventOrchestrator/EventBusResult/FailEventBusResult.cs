namespace Microservices.EventOrchestrator.EventBusResult
{
    public class FailEventBusResult : EventBusBaseResult
    {
        public FailEventBusResult():base(false)
        {

        }


        public FailEventBusResult(string message):base(false,message)
        {

        }
    }
}
