class Hej : IMessageAction
{
    public void Action(string clientId, string topic, string data)
    {
        System.Console.WriteLine($"{nameof(Hej)}");
    }

    public bool CanExecute(string clientId, string topic, string data)
    {
        return (topic == "Hej");
    }
};