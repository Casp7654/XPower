using MQTTnet;
using MQTTnet.Server;

class BrokerServerHandler : IServerHandler
{
    /// <summary>
    /// The id of the server used to identify the machine in the mqtt connections
    /// </summary>
    /// <value></value>
    public string ServerId { get; private set; }
    
    /// <summary>
    /// The mqtt server which handles the connections and data.
    /// </summary>
    private readonly MqttServer _mqttServer;

    public BrokerServerHandler(MqttServer mqttServer)
    {
        _mqttServer = mqttServer;
        ServerId = "Broker";
    }

    /// <summary>
    /// Publishes a message to the given topic
    /// </summary>
    /// <param name="topic">The topic the message should be delivered on.</param>
    /// <param name="data">The application data to send.</param>
    /// <returns>A task which can be awaited</returns>
    public async Task Publish(string topic, string data)
    {
        var message = new MqttApplicationMessageBuilder()
        .WithTopic("Led/All")
        .WithPayload(data)
        .Build();

        await _mqttServer.InjectApplicationMessage(
            new InjectedMqttApplicationMessage(message) {
                SenderClientId = "Broker"
            }
        );
    }

    public async Task StartAsync()
    {
        await _mqttServer.StartAsync();
    }

    public async Task StopAsync()
    {
        await _mqttServer.StopAsync();
    }
}
