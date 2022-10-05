namespace XPowerApi.DbModels.SurrealDbModels
{
    public class RelateObject
    {
        public string Id { get; set; }

        /// <summary>
        /// The incoming models record link
        /// ex: user:1
        /// </summary>
        public string In { get; set; }

        /// <summary>
        /// The outcoming models record link
        /// ex: hub:1
        /// </summary>
        public string Out { get; set; }

        public RelateObject(string Id, string In, string Out)
        {
            this.Id = Id;
            this.In = In;
            this.Out = Out;
        }
    }
}