using System.Text.Json;

namespace XPowerApi.DbModels.SurrealDbModels;

public static class SurrealDbResultFactory
{
    private static SurrealDbResult MakeRawResult(string jsonData)
    {
        List<SurrealDbResult> dbResult = JsonSerializer.Deserialize<List<SurrealDbResult>>(jsonData)!; 
        return dbResult[0];
    }
    public static T MakeOne<T>(string jsonData)
    {
        SurrealDbResult dbResult = MakeRawResult(jsonData);
        T t = JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(dbResult.result[0]))!;
        return t;
    }

    //public static List<T> MakeAll<T>(string jsonData)
    //{
        //SurrealDbResult dbResult = MakeRawResult(jsonData);
        //List<T> tList = new List<T>();
        //foreach??=>!!JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(dbResult.result[i]))!;
        //return tList;
    //}
}