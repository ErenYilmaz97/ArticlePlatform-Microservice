using MediatR;
using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.EventBusResult;

namespace Microservices.EventBus.Orchestrator.EventOrchestrator;

public class EventOrchestrator
{
    private readonly IMediator _mediator;

    public EventOrchestrator(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task<IEventBusResult> HandleEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        return await _mediator.Send(@event);
    }
}