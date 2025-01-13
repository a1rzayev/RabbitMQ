using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQAPI.RabbitMQ;
public class MqConsumer : MqBase
{
    readonly EventingBasicConsumer _consumer;
    public MqConsumer(ConnectionFactory factory) : base(factory)
    {
        _consumer = new EventingBasicConsumer(Channel);
    }
    public void AddListener(string queueName, EventHandler<BasicDeliverEventArgs> handler)
    {
        _consumer.Received += handler;
        CreateQueueIfNotExists(queueName);
        Channel.BasicConsume(queue: queueName, autoAck: true, consumer: _consumer, noLocal: false, exclusive: false, consumerTag: Guid.NewGuid().ToString(), arguments: new Dictionary<string, object>());
    }
    public void RemoveListener(EventHandler<BasicDeliverEventArgs> handler)
    {
        _consumer.Received -= handler;
    }
}