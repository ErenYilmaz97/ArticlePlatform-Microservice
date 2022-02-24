using Microservices.EventBus.Orchestrator.Event.Interface;
using Microservices.EventBus.Orchestrator.EventInfo.Chat;

namespace Microservices.EventBus.Orchestrator.Event.Chat;

public class ChatTestEvent : IGenericEvent<ChatTestEventInfo>
{
    public string GetEventName()
    {
        return "ChatTestEvent";
    }

    public ChatTestEventInfo EventInfo { get; set; }
}