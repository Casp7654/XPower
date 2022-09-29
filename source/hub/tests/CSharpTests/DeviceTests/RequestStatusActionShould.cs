namespace CSharpTests;


public class RequestStatusActionShould
{
    [Fact]
    void RequestStatusAction_CanExecute() {
        // Arrange
        var deviceManager = A.Fake<IDeviceManager>();
        var handler = A.Fake<IServerHandler>();

        var action = new RequestStatusAction(deviceManager, handler);
        
        Assert.True(action.CanExecute("","StatusRequest/all", ""));
    }
}