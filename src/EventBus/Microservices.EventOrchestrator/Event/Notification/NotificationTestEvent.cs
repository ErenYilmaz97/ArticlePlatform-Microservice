using Microservices.EventOrchestrator.Event.Abstract;
using Microservices.EventOrchestrator.EventInfoObject.Notification;

namespace Microservices.EventOrchestrator.Event.Notification
{
    public class NotificationTestEvent : Event<NotificationTestEventInfo>
    {
        public NotificationTestEvent(NotificationTestEventInfo eventInfo):base(eventInfo)
        {
                
        }
    }
}
