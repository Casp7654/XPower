namespace XPowerApi.Models.HubModels
{
    public class Hub
    {
        /// <summary>
        /// The id representing the hub.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The name of the hub.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The mac address of the hub.
        /// </summary>
        public string Mac { get; set; }
        
        /// <summary>
        /// The home which the hub belongs to.
        /// </summary>
        public string Home { get; set; }
        
        /// <summary>
        /// The private address of the hub.
        /// </summary>
        public string PrivateAddress { get; set; }
        
        /// <summary>
        /// The public address of the hub.
        /// </summary>
        public string PublicAddress { get; set; }
    }
}
