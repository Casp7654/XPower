interface IServerHandler {

    // Starts the server asynchrous
    Task StartAsync();

    // Publish data to the given topic
    Task Publish(string topic, string data);

    // Stops the server asynchrous
    Task StopAsync();   
}