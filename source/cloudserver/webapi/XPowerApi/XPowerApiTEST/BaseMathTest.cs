namespace XPowerApiTEST
{
    public class BaseMathTest
    {
        [Fact]
        public void BasePlusTest()
        {
            int expteted = 10;

            int actual = 5 + 5;

            Assert.Equal(expteted, actual);
        }
    }
}