using XPowerApi.Models.HomeModels;

namespace XPowerApi.Models.UserModels
{
    public class UserGroup
    {
        /// <summary>
        /// The id representing the user group.
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// The home which the user belongs to.
        /// </summary>
        public Home Home { get; set; }
    }
}