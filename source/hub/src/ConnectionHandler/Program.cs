using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;

var mqttFactory = new MqttFactory();

var options = new MqttServerOptionsBuilder()
.WithDefaultEndpoint()
.Build();

var mqtt = mqttFactory.CreateMqttServer(options);

var server = new MqttServerHandler(mqtt);
server.MessageEventHandler += (cl, t, p) => {System.Console.WriteLine($"{cl}: {t} {p}");};
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


/* using (var server = mqttFactory.CreateMqttServer(options)) 
{
    await server.StartAsync();

    bool quit = false;
    while(!quit) 
    {
        System.Console.Write("Should turn on? y/n: ");
        var key = Console.ReadLine();

        string turn_on = "off";
        if (key == "y")
            turn_on = "on";

        var jsonMessage = System.Text.Json.JsonSerializer.Serialize(new {cmd = turn_on});

        var message = new MqttApplicationMessageBuilder()
        .WithTopic("Led/All")
        .WithPayload(jsonMessage)
        .Build();

        await server.InjectApplicationMessage(
            new InjectedMqttApplicationMessage(message) {
                SenderClientId = "Broker"
            }
        );
    }

    await server.StopAsync();
} */