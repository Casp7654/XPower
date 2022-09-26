using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;

var mqttFactory = new MqttFactory();

var options = new MqttServerOptionsBuilder()
.WithDefaultEndpoint()
.Build();

var mqtt = mqttFactory.CreateMqttServer(options);
var server = new MqttServerHandler(mqtt);

var actions = new List<IMessageAction> {
    new SampleAction()
};
var serverController = new ServerController(actions, server);
await server.StartAsync();

using (var mqttClient = mqttFactory.CreateMqttClient())
{
    var mqttClientOptions = new MqttClientOptionsBuilder()
        .WithTcpServer("127.0.0.1")
        .Build();

    await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

    var applicationMessage = new MqttApplicationMessageBuilder()
        .WithTopic("test")
        .WithPayload("hejsa")
        .Build();

    await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
}

Console.ReadKey();