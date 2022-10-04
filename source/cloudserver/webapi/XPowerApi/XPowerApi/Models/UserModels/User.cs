namespace XPowerApi.Models.UserModels
{
    public class User
    {
        /// <summary>
        /// The id representing the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The users username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The users email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The firstname of the user.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// The lastname of the user.
        /// </summary>
        public string Lastname { get; set; }
    }
}