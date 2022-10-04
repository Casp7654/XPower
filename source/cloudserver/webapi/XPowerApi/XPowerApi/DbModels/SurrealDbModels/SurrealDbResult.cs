namespace XPowerApi.DbModels.SurrealDbModels
{
    public class SurrealDbResult
    {
        /// <summary>
        /// The time the result was created
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// The status of the result:
        /// ex: Ok, Failed
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// List of results
        /// </summary>
        public List<object> result { get; set; }
    }
}