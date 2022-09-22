using System.Text.Json;
using XPowerApi.DbModels;


namespace XPowerApi.Models.SurrealDbModels;

public static class SurrealDbResultFactory
{
    public static SurrealDbResult MakeRawResult(string responseJson)
    {
        List<SurrealDbResult> dbresult = JsonSerializer.Deserialize<List<SurrealDbResult>>(responseJson)!; 
        return dbresult[0];
    }
    public static T MakeOne<T>(string responseJson)
    {
        SurrealDbResult dbResult = MakeRawResult(responseJson);
        T t = JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(dbResult.result[0]))!;
        return t;
    }
}