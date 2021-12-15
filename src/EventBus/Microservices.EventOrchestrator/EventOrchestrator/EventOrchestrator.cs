using MediatR;
using Microservices.EventOrchestrator.EventBusResult;
using Microservices.EventOrchestrator.OrchestratorEvent.Abstract;

namespace Microservices.EventOrchestrator.EventOrchestrator
{
    public class EventOrchestrator
    {
        private readonly IMediator _mediator;

        public EventOrchestrator(IMediator mediator)
        {
            this._mediator = mediator;
        }


        //İlgili orchestratoreventi handle ederek eventi queueye publish ediyoruz
        public async Task<IEventBusResult> HandleOrchestrationEvent<TOrchestraterEvent>(TOrchestraterEvent @event) where TOrchestraterEvent : class, IOrchestratorEvent
        {
            var handleResult = await _mediator.Send(@event);
            return handleResult;
        }
    }
}
