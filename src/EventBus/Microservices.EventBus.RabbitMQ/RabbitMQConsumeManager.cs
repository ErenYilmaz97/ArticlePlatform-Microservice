using Microservices.EventBus.RabbitMQ.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Microservices.EventBus.RabbitMQ;

public class RabbitMQConsumeManager
{
    private ConnectionFactory _connectionFactory;
    private IConnection _connection;
    private IModel _channel;

    public RabbitMQConsumeManager()
    {
        if(IsConnectionClosed())
            CreateConnection();
    }




    public ConsumeMessageOutput ConsumeMessage(ConsumeMessageInput input)
    {
        this._channel.BasicQos(0, 1, false);

        var consumer = new EventingBasicConsumer(_channel);
        _channel.BasicConsume(input.QueueName, false, consumer);

        try
        {
            consumer.Received += (sender, args) =>
            {
                input.ConsumerMethot.Invoke(sender, args);
            };

            return new() { IsSuccess = true, ResultMessage = $"{input.QueueName} Listening."};
        }
        catch
        {
            throw new ApplicationException("Error occured when listening queue.");
        }
    }


    public void RemoveMessageFromQueue(ulong deliveryTag)
    {
        _channel.BasicAck(deliveryTag, false);
    }

    private bool IsConnectionClosed()
    {
        return _connectionFactory is null || _connection is null || _channel is null || !_connection.IsOpen;
    }


    private void CreateConnection()
    {
        _connectionFactory = new ConnectionFactory() { Uri = new Uri(RabbitMQConstants.Uri) };
        _connection = _connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();
    }
}