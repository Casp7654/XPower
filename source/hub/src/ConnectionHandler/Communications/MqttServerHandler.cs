using MQTTnet;
using MQTTnet.Server;

class MqttServerHandler : IServerHandler
{
    /// <summary>
    /// The id of the server used to identify the machine in the mqtt connections
    /// </summary>
    /// <value></value>
    public string ServerId { get; private set; }

    /// <summary>
    /// The event handler when a message is received
    /// </summary>
    public Action<string, string, string>? MessageEventHandler { get; set; }

    /// <summary>
    /// The mqtt server which handles the connections and data.
    /// </summary>
    private readonly MqttServer _mqttServer;

    public MqttServerHandler(MqttServer mqttServer)
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
        .WithTopic(topic)
        .WithPayload(data)
        .Build();

        await _mqttServer.InjectApplicationMessage(
            new InjectedMqttApplicationMessage(message) {
                SenderClientId = "Broker"
            }
        );
    }

    /// <summary>
    /// Starts the server
    /// </summary>
    /// <returns>A task which can be awaited</returns>
    public async Task StartAsync()
    {
        _mqttServer.ApplicationMessageNotConsumedAsync += OnMessageNotConsumedAsync;

        await _mqttServer.StartAsync();
    }

    /// <summary>
    /// Stops the server
    /// </summary>
    /// <returns>A task which can be awaited</returns>
    public async Task StopAsync()
    {
        await _mqttServer.StopAsync();
    }

    /// <summary>
    /// Called when message not consumed event is called.
    /// </summary>
    private async Task OnMessageNotConsumedAsync(ApplicationMessageNotConsumedEventArgs packet) 
    {
        var clientId = packet.SenderId;
        var topic = packet.ApplicationMessage.Topic;
        var payload = packet.ApplicationMessage.ConvertPayloadToString();
        await Task.Run(() => 
            MessageEventHandler?.Invoke(clientId, topic, payload)
        );
    }
}
