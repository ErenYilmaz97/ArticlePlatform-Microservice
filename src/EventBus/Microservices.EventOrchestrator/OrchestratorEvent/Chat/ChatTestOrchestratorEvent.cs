using Microservices.EventOrchestrator.Event.Chat;
using Microservices.EventOrchestrator.EventInfoObject.Chat;
using Microservices.EventOrchestrator.OrchestratorEvent.Abstract;

namespace Microservices.EventOrchestrator.OrchestratorEvent.Chat
{
    public class ChatTestOrchestratorEvent : IGenericOrchestratorEvent<ChatTestEvent,ChatTestEventInfo>
    {
        public ChatTestEventInfo EventInfo { get; set; }
    }
}
