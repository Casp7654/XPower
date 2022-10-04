using System.Text.Json;
using XPowerApi.Interfaces;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Providers
{
    public class SurrealDbProvider : ISurrealDbProvider
    {
        private readonly HttpClient _HttpClient;

        public SurrealDbProvider(IConfiguration configuration)
        {
            _HttpClient = new SurrealDbHttpClient(configuration);
        }

        public SurrealDbProvider(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        /// <inheritDoc />
        public async Task<SurrealDbResult> MakeRawResult(string sqlString)
        {
            // Create RequestMessage
            SurrealDbHttpRequestMessage request = new SurrealDbHttpRequestMessage(sqlString);
            // Get Response
            HttpResponseMessage response = await _HttpClient.SendAsync(request);
            string jsonData = await response.Content.ReadAsStringAsync();
            // ERR
            if (!response.IsSuccessStatusCode)
                throw new Exception("Could not get data");
            // UnPack Result
            List<SurrealDbResult> dbResult = JsonSerializer.Deserialize<List<SurrealDbResult>>(jsonData)!;

            return dbResult.FirstOrDefault();
        }

        /// <inheritDoc />
        public async Task<T> Create<T>(string tableName, Dictionary<string, string> dataArray) where T : new()
        {
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

        /// <inheritDoc />
        public async Task<RelateObject> Relate(string fromId, string toId, string byName)
        {
            string sqlString = $"relate {fromId}->{byName}->{toId};";
            SurrealDbResult dbResult = await MakeRawResult(sqlString);
            RelateObject relateObject =
                JsonSerializer.Deserialize<RelateObject>(JsonSerializer.Serialize(dbResult.result[0]))!;
            return relateObject;
        }

        /// <inheritDoc />
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

        /// <inheritDoc />
        public async Task<T> GetOneById<T>(string tableName, int id)
        {
            string sqlString = $"select * from {tableName} where id = {tableName}:{id} limit 1;";
            SurrealDbResult dbResult = await MakeRawResult(sqlString);
            T t = JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(dbResult.result[0]))!;
            return t;
        }

        /// <inheritDoc />
        public async Task<RelateObject> GetRelation(string subjectId, string relationName, string alias = "")
        {
            string sqlString = $"select ->{relationName} ";
            sqlString += (!String.IsNullOrWhiteSpace(alias)) ? "" : $"as {alias} ";
            sqlString += $" from {subjectId};";
            SurrealDbResult dbResult = await MakeRawResult(sqlString);
            Dictionary<string, string> jsonObject =
                JsonSerializer.Deserialize<Dictionary<string, string>>(JsonSerializer.Serialize(dbResult.result[0]))!;
            RelateObject relateObject = new RelateObject(jsonObject["id"], jsonObject["in"], jsonObject["out"]);
            return relateObject;
        }

        /// <inheritDoc />
        public async Task<List<T>> GetOneFromInsideAnother<T>(string tableName, string baseTable, string targetId)
        {
            string sqlString = $"select * from ${tableName} where ${baseTable} inside (select id from ${targetId});";
            SurrealDbResult dbResult = await MakeRawResult(sqlString);
            List<T> objectList = JsonSerializer.Deserialize<List<T>>(JsonSerializer.Serialize(dbResult.result[0]))!;
            return objectList;
        }

        /// <inheritDoc />
        public async Task<List<T>> GetOneFromInsideARelation<T>(string tableName, string baseTable, string relationTable, string targetId)
        {
            string sqlString =
                $"select * from ${tableName} where ${baseTable} inside (select out as id from ${relationTable} where in is ${targetId});";
            SurrealDbResult dbResult = await MakeRawResult(sqlString);
            List<T> objectList = JsonSerializer.Deserialize<List<T>>(JsonSerializer.Serialize(dbResult.result[0]))!;
            return objectList;
        }

        /// <inheritDoc />
        public async Task<T> GetOneByField<T>(string tableName, string field, string value)
        {
            string sqlString = $"select * from {tableName} where {field} = \"{value}\" limit 1;";
            SurrealDbResult dbResult = await MakeRawResult(sqlString);
            T t = JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(dbResult.result[0]))!;
            return t;
        }
    }
}