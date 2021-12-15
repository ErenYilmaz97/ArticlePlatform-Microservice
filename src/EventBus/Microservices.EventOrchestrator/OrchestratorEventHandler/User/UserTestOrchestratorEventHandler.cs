using MediatR;
using Microservices.EventOrchestrator.Event.User;
using Microservices.EventOrchestrator.EventBusResult;
using Microservices.EventOrchestrator.EventInfoObject.User;
using Microservices.EventOrchestrator.EventPublisher.Abstract;
using Microservices.EventOrchestrator.OrchestratorEvent.User;

namespace Microservices.EventOrchestrator.OrchestratorEventHandler.User
{
    public class UserTestOrchestratorEventHandler : IRequestHandler<UserTestOrchestratorEvent, IEventBusResult>
    {
        private readonly IEventPublisher _eventPublisher;

        public UserTestOrchestratorEventHandler(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }


        public async Task<IEventBusResult> Handle(UserTestOrchestratorEvent request, CancellationToken cancellationToken)
        {
            try
            {
                var eventInfo = new UserTestEventInfo() { TestValue = "IdentityTestValue" };
                var userTestEvent = new UserTestEvent(eventInfo);

                this._eventPublisher.PublishUserEvent<UserTestEvent>("UserTestEvent", userTestEvent);
                return new SuccessEventBusResult();
            }
            catch (Exception)
            {
                return new FailEventBusResult("UserTestEvent Publish Edilemedi.");
            }
        }
    }
}
