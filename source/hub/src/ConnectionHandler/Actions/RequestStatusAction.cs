using System.Text.Json;
using System;
using MQTTnet;
using MQTTnet.Client;
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
        await _serverHandler.PublishAsync("StatusResponse/all", JsonSerializer.Serialize(_deviceManager.GetDeviceStatusResponses()));
    }

    public bool CanExecute(string clientId, string topic, string data)
    {
        return (topic.ToLower() == "statusrequest");
    }
};