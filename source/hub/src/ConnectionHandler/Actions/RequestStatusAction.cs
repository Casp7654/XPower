using System.Text.Json;
using System;
using MQTTnet;
using MQTTnet.Client;
public class RequestStatusAction : IMessageAction
{
    private readonly IDeviceManager _deviceManager;
    private readonly IServerHandler _serverHandler;
    public RequestStatusAction(IDeviceManager deviceManager, IServerHandler serverHandler)
    {
        _deviceManager = deviceManager;
        _serverHandler = serverHandler;
    }

    public async void Action(string clientId, string topic, string data)
    {
        // Publish connected devices that are offline and their status
        await _serverHandler.PublishAsync("StatusResponse/all", JsonSerializer.Serialize(_deviceManager.GetDeviceStatusResponses()));
    }

    public bool CanExecute(string clientId, string topic, string data)
    {
        return (topic.ToLower() == "statusrequest/all");
    }
};