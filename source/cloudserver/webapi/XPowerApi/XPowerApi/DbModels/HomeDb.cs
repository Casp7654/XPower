using XPowerApi.Models.HomeModels;

namespace XPowerApi.DbModels
{
    public class HomeDb
    {
        /// <summary>
        /// The id represented in the db.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The name of the home represented in the db.
        /// </summary>
        /// <value></value>
        public string name { get; set; }

        /// <summary>
        /// Converts the current HomeDb object to Home object
        /// </summary>
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