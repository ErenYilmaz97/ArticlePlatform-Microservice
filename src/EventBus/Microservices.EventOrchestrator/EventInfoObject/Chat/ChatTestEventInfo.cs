using Microservices.EventOrchestrator.Event.Chat;
using Microservices.EventOrchestrator.EventInfoObject.Abstract;

namespace Microservices.EventOrchestrator.EventInfoObject.Chat
{
    public class ChatTestEventInfo : IEventInfoObject<ChatTestEvent>
    {
        public string TestValue { get; set; }
    }
}
