using System.Text.Json;

namespace XPowerApi.Models;

public static class SurrealDbResultFactory
{
    public static SurrealDbResult MakeResult(string responseJson)
    {
        List<SurrealDbResult> dbresult = JsonSerializer.Deserialize<List<SurrealDbResult>>(responseJson);
        return dbresult[0];
    }
}