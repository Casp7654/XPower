using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Interfaces;

public interface ISurrealDbProvider
{
    Task<SurrealDbResult> MakeRawResult(string sqlString);
    Task<T> Create<T>(string tableName, Dictionary<string, string> dataArray) where T : new();

    Task<RelateObject> Relate(string fromId, string toId, string byName);

    Task<int> GetNextId(string tableName);

    Task<T> GetOneById<T>(string tableName, int id);

    Task<RelateObject> GetRelation(string subjectId, string relationName, string alias = "");

    Task<List<T>> GetOneFromInsideAnother<T>(string tableName, string baseTable, string targetId);

    Task<List<T>> GetOneFromInsideARelation<T>(string tableName, string baseTable, string relationTable, string targetId);
    Task<T> GetOneByField<T>(string tableName, string field, string value);
}
