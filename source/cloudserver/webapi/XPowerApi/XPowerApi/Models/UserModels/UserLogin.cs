namespace XPowerApi.Models.UserModels
{
    public class UserLogin
    {
        /// <summary>
        /// The username used to login.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password which will be used to login.
        /// </summary>
        public string Password { get; set; }
    }
}
