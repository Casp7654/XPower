namespace XPowerIoTHandlerTEST
{
    public class BaseStringTest
    {
        [Fact]
        public void Test1()
        {
            string expected = "Hello";

            string actual = "Hell" + "o";

            Assert.Equal(expected, actual);
        }
    }
}