using MQTTnet;
using MQTTnet.Server;

var t = new BrokerServerHandler();

var mqttFactory = new MqttFactory();

var options = new MqttServerOptionsBuilder()
.WithDefaultEndpoint()
.Build();

using (var server = mqttFactory.CreateMqttServer(options)) 
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
}