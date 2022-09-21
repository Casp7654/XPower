interface IServerHandler {

    /// <summary>
    /// Event for when the server receives data.
    /// ClientId, TopicName, Payload
    /// </summary>
    Action<string, string, string>? MessageEventHandler { get; set; }

    /// <summary>
    /// Starts the server
    /// </summary>
    /// <returns>A task which can be awaited</returns>
    Task StartAsync();

    /// <summary>
    /// Publishes data on the topic, with the given data.
    /// </summary>
    /// <param name="topic">The channel to publish to</param>
    /// <param name="data">The data to publish</param>
    /// <returns>A task which can be awaited</returns>
    Task Publish(string topic, string data);

    /// <summary>
    /// Stops the server
    /// </summary>
    /// <returns>A task which can be awaited</returns>
    Task StopAsync();   
}