using MediatR;
using Microservices.EventBus.Orchestrator.Event.Chat;
using Microservices.EventBus.Orchestrator.EventBusResult;

namespace Microservices.EventBus.Orchestrator.OrchestratorHandler.Chat;

public class ChatTestEventHandler : IRequestHandler<ChatTestEvent, IEventBusResult>
{
    public Task<IEventBusResult> Handle(ChatTestEvent request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}