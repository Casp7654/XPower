using XPowerApi.Models.HomeModels;

namespace XPowerApi.DbModels
{
    public class HomeDb
    {
        public string id { get; set; }

        public string name { get; set; }

        public Home ConvertToHome()
        {
            return new Home
            {
                Id = int.Parse(id.Split(':')[1]),
                Name = name,
            };
        }
    }
}