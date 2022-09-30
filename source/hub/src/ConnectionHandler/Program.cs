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
    new RequestStatusAction(new DeviceManager(), server)
};
var serverController = new ServerController(actions, server);
await server.StartAsync();

Console.ReadKey();