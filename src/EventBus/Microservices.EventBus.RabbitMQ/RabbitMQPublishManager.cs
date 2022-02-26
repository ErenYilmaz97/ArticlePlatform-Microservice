using System.Runtime.InteropServices;
using Microservices.EventBus.RabbitMQ.Models;
using RabbitMQ.Client;

namespace Microservices.EventBus.RabbitMQ;

public class RabbitMQPublishManager
{
    private  ConnectionFactory _connectionFactory;
    private  IConnection _connection;
    private  IModel _channel;

    public RabbitMQPublishManager()
    {
        CreateConnection();
    }

    public PublishMessageOutput PublishMessage(PublishMessageInput input)
    {
        if(IsConnectionClosed())
            CreateConnection();

        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;

        try
        {
            _channel.BasicPublish(exchange: input.ExchangeName, routingKey: input.RouteKey, basicProperties: properties, body: input.Message);
            return new(){IsSuccess = true, ResultMessage = "Message Published."};
        }
        catch
        {
            return new() { IsSuccess = false, ResultMessage = "Message Did not Published." };
        }
    }


    private bool IsConnectionClosed()
    {
        return _connectionFactory is null || _connection is null || _channel is null || !_connection.IsOpen;
    }

    private void CreateConnection()
    {
        _connectionFactory = new ConnectionFactory() { Uri = new Uri(RabbitMQConstants.Uri)};
        _connection = _connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();
    }

}