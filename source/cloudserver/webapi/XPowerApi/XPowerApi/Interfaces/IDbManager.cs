namespace XPowerApi.Interfaces;

public interface IDbManager
{
    public T Create<T>(string tableName, T newT);
    
    public int GetNextId(string tableName);
    public T GetOne<T>(string tableName, int? id, string whereClause = "");
    public T GetSpecific<T>(string tableName, string whereClause = "");
    public T GetAll<T>(string tableName);

    public T Update<T>(string tableName, int id,  T newT);
    
    public T Delete<T>(string tableName, T oldT);
        
}