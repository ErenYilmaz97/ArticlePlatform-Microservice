using Microservices.EventOrchestrator.Event.Abstract;
using Microservices.EventOrchestrator.EventInfoObject.Chat;

namespace Microservices.EventOrchestrator.Event.Chat
{
    public class ChatTestEvent : Event<ChatTestEventInfo>
    {
        public ChatTestEvent(ChatTestEventInfo eventInfo):base(eventInfo)
        {

        }
    }
}
