using System.Text.Json;
using System.Text.Json.Nodes;
using XPowerApi.Interfaces;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Providers;

public class SurrealDbProvider : IDbManager
{
    private SurrealDbHttpClient _httpClient;

    public SurrealDbProvider(IConfiguration configuration)
    {
        _httpClient = new SurrealDbHttpClient(configuration);
    }

    private async Task<SurrealDbResult> MakeRawResult(string sqlString)
    {
        // Create RequestMessage
        SurrealDbHttpRequestMessage request = new SurrealDbHttpRequestMessage(sqlString);
        // Get Response
        HttpResponseMessage response = await _httpClient.SendAsync(request);
        string jsonData = await response.Content.ReadAsStringAsync();
        // Debug Raw Response 
        //Console.WriteLine(responseJson);
        // ERR
        if (!response.IsSuccessStatusCode)
            throw new Exception("Could not get data");
        // UnPack Result
        List<SurrealDbResult> dbResult = JsonSerializer.Deserialize<List<SurrealDbResult>>(jsonData)!;

        return dbResult[0];
    }

    public async Task<T> Create<T>(string tableName, Dictionary<string, string> dataArray) where T : new()
    {
        // TODO: Fix Db Create
        // Get Next id in table
        int newId = await GetNextId(tableName);
        dataArray.Add("id", $"{newId}");
        // Set Base SQL
        string sqlString = $"insert into {tableName} " + "{";
        // loop data array to add params
        foreach (KeyValuePair<string, string> dataIndex in dataArray)
        {
            sqlString += $"{dataIndex.Key}:";
            sqlString += (int.TryParse(dataIndex.Value, out int irrelevant))
                ? $"{dataIndex.Value},"
                : $"\"{dataIndex.Value}\",";
        }

        // trim last ,
        sqlString = sqlString.TrimEnd(',') + "};";
        // Make Request
        SurrealDbResult dbResult = await MakeRawResult(sqlString);
        // Return Created DB Object
        T t = (dbResult.status == "OK") ? await GetOneById<T>(tableName, newId) : new T();
        return t;
    }

    public async Task<RelateObject> Relate(string fromId, string toId, string byName)
    {
        string sqlString = $"relate {fromId}->{byName}->{toId};";
        SurrealDbResult dbResult = await MakeRawResult(sqlString);
        RelateObject relateObject =
            JsonSerializer.Deserialize<RelateObject>(JsonSerializer.Serialize(dbResult.result[0]))!;
        return relateObject;
    }

    public async Task<int> GetNextId(string tableName)
    {
        int id = 1;
        // Set SQL string
        string sqlString = $"select id from {tableName} order by id desc limit 1;";
        SurrealDbResult dbResult = await MakeRawResult(sqlString);
        if (dbResult.result.Count >= 1)
        {
            // Spaghetti
            IdObject t = JsonSerializer.Deserialize<IdObject>(JsonSerializer.Serialize(dbResult.result[0]))!;
            id = int.Parse(t.id.Split(':')[1]);
            id = (id != 0) ? id + 1 : 1;
        }

        return id;
    }

    public async Task<T> GetOneById<T>(string tableName, int id)
    {
        string sqlString = $"select * from {tableName} where id = {tableName}:{id} limit 1;";
        SurrealDbResult dbResult = await MakeRawResult(sqlString);
        T t = JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(dbResult.result[0]))!;
        return t;
    }

    public async Task<T> GetSpecific<T>(string tableName, string whereClause = "")
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetAll<T>(string tableName)
    {
        throw new NotImplementedException();
    }

    public async Task<RelateObject> GetRelation(string subjectId, string relationName, string alias = "")
    {
        string sqlString = $"select id, ->{relationName} ";
        sqlString += (!String.IsNullOrWhiteSpace(alias)) ? "" : $"as {alias} ";
        sqlString += $" from {subjectId};";
        SurrealDbResult dbResult = await MakeRawResult(sqlString);
        Dictionary<string,string> jsonObject = JsonSerializer.Deserialize<Dictionary<string,string>>(JsonSerializer.Serialize(dbResult.result[0]))!;
        RelateObject relateObject = new RelateObject(jsonObject["id"],jsonObject["in"],jsonObject["out"]);
        return relateObject;
    }

    public async Task<T> Update<T>(string tableName, int id, T newT)
    {
        throw new NotImplementedException();
    }

    public async Task<T> Delete<T>(string tableName, T oldT)
    {
        throw new NotImplementedException();
    }
}