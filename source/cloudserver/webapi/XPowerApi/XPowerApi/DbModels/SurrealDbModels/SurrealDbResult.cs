namespace XPowerApi.DbModels.SurrealDbModels;

public class SurrealDbResult
{
    public string time { get; set; }
    public string status { get; set; }
    public List<object> result { get; set; }
}