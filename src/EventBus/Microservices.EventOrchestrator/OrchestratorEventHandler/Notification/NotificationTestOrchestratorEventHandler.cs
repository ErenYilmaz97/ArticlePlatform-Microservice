using MediatR;
using Microservices.EventOrchestrator.Event.Notification;
using Microservices.EventOrchestrator.EventBusResult;
using Microservices.EventOrchestrator.EventInfoObject.Notification;
using Microservices.EventOrchestrator.EventPublisher.Abstract;
using Microservices.EventOrchestrator.OrchestratorEvent.Notification;

namespace Microservices.EventOrchestrator.OrchestratorEventHandler.Notification
{
    public class NotificationTestOrchestratorEventHandler : IRequestHandler<NotificationTestOrchestratorEvent, IEventBusResult>
    {
        private readonly IEventPublisher _eventPublisher;

        public NotificationTestOrchestratorEventHandler(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }


        public async Task<IEventBusResult> Handle(NotificationTestOrchestratorEvent request, CancellationToken cancellationToken)
        {
            try
            {
                var eventInfo = new NotificationTestEventInfo() { TestValue = "IdentityTestValue" };
                var notifTestEvent = new NotificationTestEvent(eventInfo);

                this._eventPublisher.PublishNotificationEvent<NotificationTestEvent>("NotificationTestEvent", notifTestEvent);
                return new SuccessEventBusResult();
            }
            catch (Exception)
            {
                return new FailEventBusResult("NotificationTestEvent Publish Edilemedi.");
            }
        }
    }
}
