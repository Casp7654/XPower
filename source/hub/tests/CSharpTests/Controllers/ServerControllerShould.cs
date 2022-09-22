namespace CSharpTests;

public class ServerControllerShould {
    
    [Fact]
    void CallMessageReceived_WhenServerHandlerReceivesMessage() {
        // Arrange
        var action = A.Fake<IMessageAction>();
        var actions = new List<IMessageAction> {
            action
        };

        var handler = A.Fake<IServerHandler>();
        var controller = new ServerController(actions, handler);
        
        // Act
        handler.MessageEventHandler?.Invoke("", "", "");

        // Assert
        A.CallTo(() => action.CanExecute("", "", "")).MustHaveHappenedOnceExactly();
    }

    [Fact]
    void ActionMustBeCalled_WhenCanExecuteReturnsTrue() {
        // Arrange
        var action = A.Fake<IMessageAction>();
        var actions = new List<IMessageAction> {
            action
        };

        var handler = A.Fake<IServerHandler>();
        var controller = new ServerController(actions, handler);

        A.CallTo(() => action.CanExecute("", "", "")).Returns(true);
        
        // Act
        handler.MessageEventHandler?.Invoke("", "", "");

        // Assert
        A.CallTo(() => action.Action("", "", "")).MustHaveHappenedOnceExactly();

    }
}