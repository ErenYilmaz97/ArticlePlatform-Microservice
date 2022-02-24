using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.EventInfo.Identity;

namespace Microservices.EventBus.Orchestrator.Event.Identity;

public class IdentityTestEvent : IGenericEvent<IdentityTestEventInfo>
{
    public string GetEventName()
    {
        return "IdentityTestEvent";
    }

    public IdentityTestEventInfo EventInfo { get; set; }
}