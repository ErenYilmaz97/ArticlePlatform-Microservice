using Microservices.EventBus.RabbitMQ;
using Microservices.EventBus.Orchestrator.EventOrchestrator;

namespace Microservices.EventBus.Orchestrator.OrchestratorConsumer;

public class OrchestratorConsumer : BackgroundService
{
    private readonly RabbitMQConsumeManager _rabbitMqConsumeManager;
    private readonly EventOrchestrator.EventOrchestrator _eventOrchestrator;

    public OrchestratorConsumer(RabbitMQConsumeManager rabbitMqConsumeManager, 
                                EventOrchestrator.EventOrchestrator eventOrchestrator)
    {
        _rabbitMqConsumeManager = rabbitMqConsumeManager;
        _eventOrchestrator = eventOrchestrator;
    }
    
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
    
}