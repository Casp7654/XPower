namespace CSharpTests;


public class RequestStatusActionShould
{
    [Fact]
    void RequestStatusAction_CanExecute() {

        // Arrange
        var deviceManager = A.Fake<IDeviceManager>();
        var handler = A.Fake<IServerHandler>();
        var action = new RequestStatusAction(deviceManager, handler);

        // Act
        var canExecute = action.CanExecute("","StatusRequest/all", "");

        // Assert
        Assert.True(canExecute);
    }
}