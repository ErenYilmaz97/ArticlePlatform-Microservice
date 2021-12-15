using Microservices.EventOrchestrator.Event.User;
using Microservices.EventOrchestrator.EventInfoObject.Abstract;

namespace Microservices.EventOrchestrator.EventInfoObject.User
{
    public class UserTestEventInfo : IEventInfoObject<UserTestEvent>
    {
        public string TestValue { get; set; }
    }
}
