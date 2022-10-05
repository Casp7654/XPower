using XPowerApi.Models.HubModels;

namespace XPowerApi.DbModels
{
    public class HubDb
    {
        /// <summary>
        /// The id of the hub represented in the db
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Represents the name value in the db
        /// </summary>
        public string name { get; set; }
        
        /// <summary>
        /// Represents the mac address value in the db
        /// </summary>
        public string mac { get; set; }
        
        /// <summary>
        /// Represents the home value in the db
        /// </summary>
        public string home { get; set; }
        
        /// <summary>
        /// Represents the private address value in the db
        /// </summary>
        public string private_addr { get; set; }
        
        /// <summary>
        /// Represents the public address value in the db
        /// </summary>
        public string public_addr { get; set; }

        /// <summary>
        /// Returns the hubDb model as Hub model
        /// </summary>
        public Hub ConvertToHub()
        {
            return new Hub
            {
                Id = int.Parse(id.Split(':')[1]),
                Name = name,
                Mac = mac,
                Home = home,
                PrivateAddress = private_addr,
                PublicAddress = public_addr
            };
        }
    }
}