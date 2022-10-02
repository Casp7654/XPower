using MQTTnet.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(
        o =>
        {
            o.ListenAnyIP(1883, l => l.UseMqtt()); // MQTT pipeline
            o.ListenAnyIP(5000); // Default HTTP pipeline
        });

var services = builder.Services;

services.AddHostedMqttServer(s => s.WithoutDefaultEndpoint())
    .AddMqttConnectionHandler()
    .AddConnections();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapConnectionHandler<MqttConnectionHandler>(
        "/mqtt",
        httpConnectionDispatcherOptions => httpConnectionDispatcherOptions.WebSockets.SubProtocolSelector =
                                                protocolList =>
                                                    protocolList.FirstOrDefault() ?? string.Empty);
});

app.UseMqttServer(server => {
});

app.Run();
