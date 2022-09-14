using XPowerIoTHandler.Services;

namespace XPowerIoTHandlerTEST
{
    public class GreeterServiceTest
    {
        [Fact]
        public void SayHelloWorld()
        {
            string expected = "Hello World";

            var serviceResult = new GreeterService(null).SayHello(new XPowerIoTHandler.HelloRequest() { Name = "You" }, null);
            string actual = serviceResult.Result.Message;

            Assert.Equal(expected, actual);
        }
    }
}