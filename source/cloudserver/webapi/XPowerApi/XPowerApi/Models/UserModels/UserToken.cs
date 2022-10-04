namespace XPowerApi.Models.UserModels
{
    public class UserToken : User
    {
        /// <summary>
        /// The token represented as a encrypted string.
        /// </summary>
        public string Token { get; set; }
    }
}