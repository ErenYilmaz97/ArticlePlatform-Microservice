using MediatR;
using Microservices.EventOrchestrator.Event.Chat;
using Microservices.EventOrchestrator.EventBusResult;
using Microservices.EventOrchestrator.EventInfoObject.Chat;
using Microservices.EventOrchestrator.EventPublisher.Abstract;
using Microservices.EventOrchestrator.OrchestratorEvent.Chat;

namespace Microservices.EventOrchestrator.OrchestratorEventHandler.Chat
{
    public class ChatTestOrchestratorEventHandler : IRequestHandler<ChatTestOrchestratorEvent, IEventBusResult>
    {
        private readonly IEventPublisher _eventPublisher;

        public ChatTestOrchestratorEventHandler(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }


        public async Task<IEventBusResult> Handle(ChatTestOrchestratorEvent request, CancellationToken cancellationToken)
        {
            try
            {
                var eventInfo = new ChatTestEventInfo() { TestValue = "IdentityTestValue" };
                var chatTestEvent = new ChatTestEvent(eventInfo);

                this._eventPublisher.PublishChatEvent<ChatTestEvent>("ChatTestEvent", chatTestEvent);
                return new SuccessEventBusResult();
            }
            catch (Exception)
            {
                return new FailEventBusResult("ChatTestEvent Publish Edilemedi.");
            }
        }
    }
}
