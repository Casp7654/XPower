class ServerController {

    /// <summary>
    /// The actions which will be called if they match execution pattern.
    /// </summary>
    public List<IMessageAction> Actions { get; set; }

    /// <summary>
    /// The server.
    /// </summary>
    private readonly IServerHandler _ServerHandler;

    public ServerController(List<IMessageAction> actions, IServerHandler serverHandler)
    {
        Actions = actions;
        _ServerHandler = serverHandler;
        _ServerHandler.MessageEventHandler += OnMessageReceived;
    }

    /// <summary>
    /// The method when message event is called on server
    /// </summary>
    private void OnMessageReceived(string clientId, string topic, string payload)
    {
        foreach (var action in Actions)
            if (action.CanExecute(clientId, topic, payload))
                action.Action(clientId, topic, payload);
    }
}