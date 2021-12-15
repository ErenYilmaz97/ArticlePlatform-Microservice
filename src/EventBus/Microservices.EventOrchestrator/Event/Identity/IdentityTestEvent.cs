using Microservices.EventOrchestrator.Event.Abstract;
using Microservices.EventOrchestrator.EventInfoObject.Identity;

namespace Microservices.EventOrchestrator.Event.Identity
{
    public class IdentityTestEvent : Event<IdentityTestEventInfo>
    {
        public IdentityTestEvent(IdentityTestEventInfo eventInfo):base(eventInfo)
        {

        }
    }
}
