using Microservices.EventOrchestrator.Event.Notification;
using Microservices.EventOrchestrator.EventInfoObject.Notification;
using Microservices.EventOrchestrator.OrchestratorEvent.Abstract;

namespace Microservices.EventOrchestrator.OrchestratorEvent.Notification
{
    public class NotificationTestOrchestratorEvent : IGenericOrchestratorEvent<NotificationTestEvent, NotificationTestEventInfo>
    {
        public NotificationTestEventInfo EventInfo { get; set; }
    }
}
