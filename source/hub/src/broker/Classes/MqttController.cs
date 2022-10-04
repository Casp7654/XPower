using MQTTnet.Server;

namespace broker.Classes;

sealed class MqttController
{
    public MqttController()
    {
        
    }

    public Task OnClientConnected(ClientConnectedEventArgs eventArgs)
    {
        Console.WriteLine($"Client '{eventArgs.ClientId}' connected.");
        return Task.CompletedTask;
    }

    public Task ValidateConnection(ValidatingConnectionEventArgs eventArgs)
    {
        Console.WriteLine($"Client '{eventArgs.ClientId}' wants to connect. Accepting!");
        return Task.CompletedTask;
    }

    public Task OnClientSubscribedTopic(ClientSubscribedTopicEventArgs eventArgs)
    {
        Console.WriteLine($"Client '{eventArgs.ClientId}' wants to subscribe to '{eventArgs.TopicFilter.Topic}'!");
        return Task.CompletedTask;
    }
}