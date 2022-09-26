namespace XPowerApi.Interfaces;

public interface IDbManager
{
    public Task<T> Create<T>(string tableName, Dictionary<string, string> dataArray) where T : new();

    public Task<int> GetNextId(string tableName);

    public Task<T> GetOneById<T>(string tableName, int id);
}