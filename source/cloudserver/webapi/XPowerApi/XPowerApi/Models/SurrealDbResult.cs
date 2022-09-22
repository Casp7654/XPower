using System.Text.Json;

namespace XPowerApi.Models;

public class SurrealDbResult
{
    public string time { get; set; }
    public string status { get; set; }
    public List<object> result { get; set; }
}