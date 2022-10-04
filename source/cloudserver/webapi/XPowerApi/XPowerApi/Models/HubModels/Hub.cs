namespace XPowerApi.Models.HubModels
{
    public class Hub
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Mac { get; set; }
        
        public string Home { get; set; }
        
        public string PrivateAddress { get; set; }
        
        public string PublicAddress { get; set; }
    }
}
