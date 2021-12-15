using MediatR;
using Microservices.EventOrchestrator.Constant;
using Microservices.EventOrchestrator.EventOrchestrator;
using Microservices.EventOrchestrator.EventOrchestratorConsumer;
using Microservices.EventOrchestrator.EventOrchestratorPublisher;
using Microservices.EventOrchestrator.EventPublisher.Abstract;
using Microservices.EventOrchestrator.EventPublisher.Concrete;
using RabbitMQ.Client;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IEventOrchestratorPublisher, EventOrchestratorPublisher>();
builder.Services.AddSingleton<IEventPublisher, RabbitMQEventPublisher>();
builder.Services.AddSingleton<EventOrchestrator>();

builder.Services.AddHostedService<EventOrchestratorConsumer>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

#region Declare RabbitMQ Components
var connectionFactory = new ConnectionFactory() { Uri = new Uri(RabbitMQConstants.HostUri) };
using var _connection = connectionFactory.CreateConnection();
using var _channel = _connection.CreateModel();

//Topic Exchange'i declare ediyoruz.
_channel.ExchangeDeclare(exchange: RabbitMQConstants.ExchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);

//Kuyruklarý declare ediyoruz.
_channel.QueueDeclare(queue: RabbitMQConstants.ArticleEventsQueueName, durable: true, exclusive: false, autoDelete: false);
_channel.QueueDeclare(queue: RabbitMQConstants.ChatEventsQueueName, durable: true, exclusive: false, autoDelete: false);
_channel.QueueDeclare(queue: RabbitMQConstants.FavoriteEventsQueueName, durable: true, exclusive: false, autoDelete: false);
_channel.QueueDeclare(queue: RabbitMQConstants.ForumEventsQueueName, durable: true, exclusive: false, autoDelete: false);
_channel.QueueDeclare(queue: RabbitMQConstants.IdentityEventsQueueName, durable: true, exclusive: false, autoDelete: false);
_channel.QueueDeclare(queue: RabbitMQConstants.NotificationEventsQueueName, durable: true, exclusive: false, autoDelete: false);
_channel.QueueDeclare(queue: RabbitMQConstants.UserEventsQueueName, durable: true, exclusive: false, autoDelete: false);
_channel.QueueDeclare(queue: RabbitMQConstants.EventOrchestratorQueueName, durable: true, exclusive: false, autoDelete: false);

//Kuyruklarý Exchange'e Bind Ediyoruz.
_channel.QueueBind(queue: RabbitMQConstants.ArticleEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.ArticleQueueBindKey);
_channel.QueueBind(queue: RabbitMQConstants.ChatEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.ChatQueueBindKey);
_channel.QueueBind(queue: RabbitMQConstants.FavoriteEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.FavoriteQueueBindKey);
_channel.QueueBind(queue: RabbitMQConstants.ForumEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.ForumQueueBindKey);
_channel.QueueBind(queue: RabbitMQConstants.IdentityEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.IdentityQueueBindKey);
_channel.QueueBind(queue: RabbitMQConstants.NotificationEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.NotificationQueueBindKey);
_channel.QueueBind(queue: RabbitMQConstants.UserEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.UserQueueBindKey);
_channel.QueueBind(queue: RabbitMQConstants.EventOrchestratorQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.OrchestratorQueueBindKey);

_connection.Close();
_connection.Dispose();
_channel.Dispose();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
