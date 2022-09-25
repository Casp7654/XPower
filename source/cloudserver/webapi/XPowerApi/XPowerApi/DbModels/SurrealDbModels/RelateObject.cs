namespace XPowerApi.DbModels.SurrealDbModels;

public class SurrealDbRelateObject
{
    public string Id { get; set; }
    
    public string In { get; set; }
    
    public string Out { get; set; }

    public SurrealDbRelateObject(string Id, string In, string Out)
    {
        this.Id = Id;
        this.In = In;
        this.Out = Out;
    }
}