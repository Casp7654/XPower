namespace XPowerApi.Interfaces;

public interface IDbManager
{
    public Task<T> Create<T>(string tableName, Dictionary<string, string> dataArray) where T : new();
    
    public Task<int> GetNextId(string tableName);
    public Task<T> GetOneById<T>(string tableName, int id);
    public Task<T> GetSpecific<T>(string tableName, string whereClause = "");
    public Task<T> GetAll<T>(string tableName);

    public Task<T> Update<T>(string tableName, int id,  T newT);
    
    public Task<T> Delete<T>(string tableName, T oldT);
        
}