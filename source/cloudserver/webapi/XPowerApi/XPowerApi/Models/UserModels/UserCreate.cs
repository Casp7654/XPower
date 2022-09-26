namespace XPowerApi.Models.UserModels
{
    public class UserCreate
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public String Email { get; set; }
        
        public String FirstName { get; set; }
        
        public String LastName { get; set; }
    }
}
