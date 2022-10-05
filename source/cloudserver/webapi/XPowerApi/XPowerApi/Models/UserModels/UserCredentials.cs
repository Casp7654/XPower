namespace XPowerApi.Models.UserModels
{
    public class UserCredentials : User
    {
        /// <summary>
        /// The salt belonging to the user.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// The hashed password belonging to the user.
        /// </summary>
        public string HashedPassword { get; set; }
    }
}
