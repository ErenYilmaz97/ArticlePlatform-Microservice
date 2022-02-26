using MediatR;
using Microservices.EventBus.Orchestrator.Event.Notification;
using Microservices.EventBus.Orchestrator.EventBusResult;
using Microservices.EventBus.Orchestrator.EventPublisher.Interface;

namespace Microservices.EventBus.Orchestrator.OrchestratorHandler.Notification;

public class NotificationTestEventHandler : IRequestHandler<NotificationTestEvent, IEventBusResult>
{
    private readonly IEventPublisher _eventPublisher;

    public NotificationTestEventHandler(IEventPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }
    public async Task<IEventBusResult> Handle(NotificationTestEvent request, CancellationToken cancellationToken)
    {
        _eventPublisher.PublishNotificationEvent(request);
        return new EventBusSuccessResult("");
    }
}