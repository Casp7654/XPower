namespace XPowerApi.Models.UserModels
{
    public class UserCredentials : User
    {
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
    }
}
