namespace Microservices.EventBus.Orchestrator.Constant;

public class RabbitMQConstants
{
    public const string HostUri = "";
    public const string ExchangeName = "Event-Router-Exchange";
    
    #region Queue Names
    public const string OrchestratorQueueName = "Orchestrator-Events-Queue";
    public const string IdentityEventsQueueName = "Identity-Events-Queue";
    public const string UserEventsQueueName = "User-Events-Queue";
    public const string ChatEventsQueueName = "Chat-Events-Queue";
    public const string NotificationEventsQueueName = "Notification-Events-Queue";
    public const string ArticleEventsQueueName = "Article-Events-Queue";
    public const string ForumEventsQueueName = "Forum-Events-Queue";
    public const string FavoriteEventsQueueName = "Favorite-Events-Queue";
    #endregion
    
    #region Queue Bind Keys
    public const string OrchestratorQueueBindKey = "Orchestrator.Event.*";
    public const string IdentityQueueBindKey = "Identity.Event.*";
    public const string UserQueueBindKey = "User.Event.*";
    public const string ChatQueueBindKey = "Chat.Event.*";
    public const string NotificationQueueBindKey = "Notification.Event.*";
    public const string ArticleQueueBindKey = "Article.Event.*";
    public const string ForumQueueBindKey = "Forum.Event.*";
    public const string FavoriteQueueBindKey = "Favorite.Event.*";
    #endregion


    #region Queue Bind Keys
    public const string OrchestratorQueueRouteKey = "Orchestrator.Event.";
    public const string IdentityQueueRouteKey = "Identity.Event.";
    public const string UserQueueRouteKey = "User.Event*";
    public const string ChatQueueRouteKey = "Chat.Event.";
    public const string NotificationQueueRouteKey = "Notification.Event.";
    public const string ArticleQueueRouteKey = "Article.Event.";
    public const string ForumQueueRouteKey = "Forum.Event.";
    public const string FavoriteQueueRouteKey = "Favorite.Event.";
    #endregion


}
