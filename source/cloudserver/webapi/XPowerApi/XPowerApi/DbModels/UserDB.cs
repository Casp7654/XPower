using XPowerApi.Models.UserModels;

namespace XPowerApi.DbModels
{
    public class UserDb
    {
        public string id { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string hashedPassword { get; set; }
        public string salt { get; set; }
        

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
    }
}