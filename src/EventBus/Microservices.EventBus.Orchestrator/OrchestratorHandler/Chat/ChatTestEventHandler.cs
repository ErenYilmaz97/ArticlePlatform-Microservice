using MediatR;
using Microservices.EventBus.Orchestrator.Event.Chat;
using Microservices.EventBus.Orchestrator.EventBusResult;
using Microservices.EventBus.Orchestrator.EventPublisher.Interface;

namespace Microservices.EventBus.Orchestrator.OrchestratorHandler.Chat;

public class ChatTestEventHandler : IRequestHandler<ChatTestEvent, IEventBusResult>
{
    private readonly IEventPublisher _eventPublisher;

    public ChatTestEventHandler(IEventPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }
    public async Task<IEventBusResult> Handle(ChatTestEvent request, CancellationToken cancellationToken)
    {
        _eventPublisher.PublishChatEvent(request);
        return new EventBusSuccessResult("");
    }
}