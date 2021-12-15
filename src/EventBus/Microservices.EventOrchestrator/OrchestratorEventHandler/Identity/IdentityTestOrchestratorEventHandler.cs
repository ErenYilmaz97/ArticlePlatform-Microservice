using MediatR;
using Microservices.EventOrchestrator.Event.Identity;
using Microservices.EventOrchestrator.EventBusResult;
using Microservices.EventOrchestrator.EventInfoObject.Identity;
using Microservices.EventOrchestrator.EventPublisher.Abstract;
using Microservices.EventOrchestrator.OrchestratorEvent.Identity;

namespace Microservices.EventOrchestrator.OrchestratorEventHandler.Identity
{
    public class IdentityTestOrchestratorEventHandler : IRequestHandler<IdentityTestOrchestratorEvent, IEventBusResult>
    {
        private readonly IEventPublisher _eventPublisher;


        public IdentityTestOrchestratorEventHandler(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public async Task<IEventBusResult> Handle(IdentityTestOrchestratorEvent request, CancellationToken cancellationToken)
        {
            try
            {
                var eventInfo = new IdentityTestEventInfo() { TestValue = "IdentityTestValue" };
                var identityTestEvent = new IdentityTestEvent(eventInfo);

                this._eventPublisher.PublishIdentityEvent<IdentityTestEvent>("IdentityTestEvent", identityTestEvent);
                return new SuccessEventBusResult();
            }
            catch (Exception)
            {
                return new FailEventBusResult("IdentityTestEvent Publish Edilemedi.");
            }
        }
    }
}
