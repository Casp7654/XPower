namespace XPowerApi.Models.UserModels
{
    public class UserCreate
    {
        /// <summary>
        /// The username which will be created for the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The password which will be created for the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The email which will be created for the user.
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// The first name which will be created for the user.
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// The last name which will be created for the user.
        /// </summary>
        public String LastName { get; set; }
    }
}