using broker.Classes;
using MQTTnet.Extensions.WebSocket4Net;
using MQTTnet.AspNetCore;
// Builder
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(
    serverOptions =>
    {
        serverOptions.ListenAnyIP(5000); // Default HTTP pipeline
        serverOptions.ListenAnyIP(1883, listenOptions => listenOptions.UseMqtt()); // MQTT pipeline
    });

// Services
var services = builder.Services;
services.AddHostedMqttServer(optionsBuilder => optionsBuilder.WithoutDefaultEndpoint())
    .AddMqttConnectionHandler()
    .AddConnections()
    .AddSingleton<MqttController>();

// App
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapConnectionHandler<MqttConnectionHandler>(
        "/mqtt",
        options => options.WebSockets.SubProtocolSelector = protocolList =>
            protocolList.FirstOrDefault() ?? string.Empty
    );
});

app.UseMqttServer(server =>
{
    MqttController mqttController = new();
    server.ValidatingConnectionAsync += mqttController.ValidateConnection;
    server.ClientConnectedAsync += mqttController.OnClientConnected;
    server.ClientSubscribedTopicAsync += mqttController.OnClientSubscribedTopic;
});
app.Run();