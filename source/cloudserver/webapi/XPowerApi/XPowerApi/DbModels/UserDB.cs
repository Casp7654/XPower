using XPowerApi.Models.UserModels;

namespace XPowerApi.DbModels
{
    public class UserDb
    {
        /// <summary>
        /// The value id represented in the db
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The value email represented in the db
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// The value firstname represented in the db
        /// </summary>
        public string firstname { get; set; }

        /// <summary>
        /// The value lastname represented in the db
        /// </summary>
        public string lastname { get; set; }

        /// <summary>
        /// The value username represented in the db
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// The value hashed_password represented in the db
        /// </summary>
        public string hashed_password { get; set; }

        /// <summary>
        /// The value salt represented in the db
        /// </summary>
        public string salt { get; set; }

        /// <summary>
        /// Converts Userdb to a user model
        /// </summary>
        public User ConvertToUser()
        {
            return new User
            {
                Id = int.Parse(id.Split(':')[1]),
                Email = email,
                Firstname = firstname,
                Lastname = lastname,
                UserName = username
            };
        }

        /// <summary>
        /// Converts a userdb model to UserCredentials
        /// </summary>
        public UserCredentials ConvertToUserCredentials()
        {
            return new UserCredentials
            {
                Id = int.Parse(id.Split(':')[1]),
                Firstname = firstname,
                Lastname = lastname,
                UserName = username,
                HashedPassword = hashed_password,
                Email = email,
                Salt = salt
            };
        }
    }
}