class TestAction : IMessageAction
{
    public void Action(string clientId, string topic, string data)
    {
        System.Console.WriteLine($"{nameof(TestAction)}");
    }

    public bool CanExecute(string clientId, string topic, string data)
    {
        return (topic == "test");
    }
};