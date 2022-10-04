namespace XPowerApi.DbModels.SurrealDbModels
{
    public class RelateObject
    {
        public string Id { get; set; }

        public string In { get; set; }

        public string Out { get; set; }

        public RelateObject(string Id, string In, string Out)
        {
            this.Id = Id;
            this.In = In;
            this.Out = Out;
        }
    }
}