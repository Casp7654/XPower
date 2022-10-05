namespace XPowerApi.Models.HubModels
{
    public class HubCreate
    {
        /// <summary>
        /// The name which will be created for the hub.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The mac address which will be created for the hub.
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// The home the hub will belong to.
        /// </summary>
        public string Home { get; set; }

        /// <summary>
        /// The private address the hub will have.
        /// </summary>
        public string PrivateAddress { get; set; }

        /// <summary>
        /// The public address the hub will have.
        /// </summary>
        public string PublicAddress { get; set; }
    }
}