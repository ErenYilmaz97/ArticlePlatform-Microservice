using Microservices.EventOrchestrator.Event.Notification;
using Microservices.EventOrchestrator.EventInfoObject.Abstract;

namespace Microservices.EventOrchestrator.EventInfoObject.Notification
{
    public class NotificationTestEventInfo : IEventInfoObject<NotificationTestEvent>
    {
        public string TestValue { get; set; }
    }
}
