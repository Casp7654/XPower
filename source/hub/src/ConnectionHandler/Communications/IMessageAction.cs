public interface IMessageAction 
{
    /// <summary>
    /// The action related to the 
    /// </summary>
    /// <param name="clientId">The client id related to message</param>
    /// <param name="topic">The topic related to message</param>
    /// <param name="data">The data related to message</param>
    void Action(string clientId, string topic, string data);

    /// <summary>
    /// Whether the current event can be executed.
    /// </summary>
    bool CanExecute(string clientId, string topic, string data);
}