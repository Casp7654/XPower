using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Interfaces;

public interface ISurrealDbProvider
{
    public Task<SurrealDbResult> MakeRawResult(string sqlString);

    public Task<T> Create<T>(string tableName, Dictionary<string, string> dataArray) where T : new();

    public Task<RelateObject> Relate(string fromId, string toId, string byName);

    public Task<int> GetNextId(string tableName);

    public Task<T> GetOneById<T>(string tableName, int id);

    public Task<RelateObject> GetRelation(string subjectId, string relationName, string alias = "");

    public Task<List<T>> GetOneFromInsideAnother<T>(string tableName, string baseTable, string targetId);

    public Task<List<T>> GetOneFromInsideARelation<T>(string tableName, string baseTable, string relationTable, string targetId);
}