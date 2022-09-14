using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPowerApi.Controllers;

namespace XPowerApiTEST
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void GetWeatherAmount()
        {
            int expected = 2;

            int actual = new WeatherForecastController(null).Get().Count();

            Assert.Equal(expected, actual);
        }
    }
}
