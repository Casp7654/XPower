namespace XPowerApi.Models.UserModels
{
    public class UserCredentials : UserLogin
    {
        public string Salt { get; set; }
    }
}
