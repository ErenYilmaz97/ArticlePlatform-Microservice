using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.EventInfo.User;

namespace Microservices.EventBus.Orchestrator.Event.User;

public class UserTestEvent : IGenericEvent<UserTestEventInfo>
{
    public string GetEventName()
    {
        return "UserTestEvent";
    }

    public UserTestEventInfo EventInfo { get; set; }
}