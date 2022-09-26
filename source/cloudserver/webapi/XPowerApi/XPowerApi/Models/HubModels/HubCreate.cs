namespace XPowerApi.Models.HubModels
{
    public class HubCreate
    {
        public string Name { get; set; }

        public string Mac { get; set; }

        public string Home { get; set; }

        public string PrivateAddress { get; set; }

        public string PublicAddress { get; set; }
    }
}