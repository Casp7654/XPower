namespace XPowerApi.Interfaces;

public interface IDbManager
{
    Task<T> Create<T>(string tableName, Dictionary<string, string> dataArray) where T : new();

    Task<int> GetNextId(string tableName);

    Task<T> GetOneById<T>(string tableName, int id);
}