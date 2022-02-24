using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.EventInfo.Notification;

namespace Microservices.EventBus.Orchestrator.Event.Notification;

public class NotificationTestEvent : IGenericEvent<NotificationTestEventInfo>
{
    public string GetEventName()
    {
        return "NotificationTestEvent";
    }

    public NotificationTestEventInfo EventInfo { get; set; }
}