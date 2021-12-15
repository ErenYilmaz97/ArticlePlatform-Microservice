namespace Microservices.EventOrchestrator.EventBusResult
{
    public class SuccessEventBusResult : EventBusBaseResult
    {
        public SuccessEventBusResult():base(true)
        {

        }


        public SuccessEventBusResult(string message):base(true,message)
        {

        }
    }
}
