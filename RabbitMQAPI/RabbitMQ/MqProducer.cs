using RabbitMQ.Client;

namespace RabbitMQAPI.RabbitMQ;

public class MqProducer : MqBase
{
    public MqProducer(ConnectionFactory factory) : base(factory)
    {
    }
    public void SendMessage(string queueName, byte[] message)
    {
        CreateQueueIfNotExists(queueName);
        Channel.BasicPublish(
            "",
            queueName,
            basicProperties: null,
            mandatory: true,
            body: message);
    }
}