using Microservices.EventOrchestrator.Event.Identity;
using Microservices.EventOrchestrator.EventInfoObject.Abstract;

namespace Microservices.EventOrchestrator.EventInfoObject.Identity
{
    public class IdentityTestEventInfo : IEventInfoObject<IdentityTestEvent>
    {
        public string TestValue { get; init; }
    }
}
