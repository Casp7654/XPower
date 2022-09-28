using System.Text.Json;
using System;

class RequestStatusAction : IMessageAction
{
    private readonly IDeviceManager _deviceManager;
    private readonly MqttServerHandler _serverHandler;
    public RequestStatusAction(IDeviceManager deviceManager, MqttServerHandler serverHandler)
    {
        _deviceManager = deviceManager;
        _serverHandler = serverHandler;
    }

    public async void Action(string clientId, string topic, string data)
    {
        Console.WriteLine(JsonSerializer.Serialize(_deviceManager.GetDevices()));
        await _serverHandler.PublishAsync("StatusResponse/all", JsonSerializer.Serialize(_deviceManager.GetDevices()));
    }

    public bool CanExecute(string clientId, string topic, string data)
    {
        Console.WriteLine(topic);
        return (topic.ToLower() == "statusrequest");
    }
};