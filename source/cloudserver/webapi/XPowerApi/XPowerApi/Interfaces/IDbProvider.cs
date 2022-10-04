namespace XPowerApi.Interfaces;

public interface IDbManager
{
    /// <summary>
    /// Creates a new entry into the table.
    /// </summary>
    /// <param name="tableName">The table to insert into</param>
    /// <param name="dataArray">Key : value format.</param>
    /// <typeparam name="T">The result expecting to get back</typeparam>
    /// <returns>db model back</returns>
    Task<T> Create<T>(string tableName, Dictionary<string, string> dataArray) where T : new();

    /// <summary>
    /// Get the last id + 1 in table
    /// </summary>
    /// <param name="tableName">The table to lookup</param>
    /// <returns>The next id.</returns>
    Task<int> GetNextId(string tableName);

    /// <summary>
    /// Get on result from the table and id given.
    /// </summary>
    /// <param name="tableName">The table to retreive from.</param>
    /// <param name="id">The id to fetch.</param>
    /// <typeparam name="T">The expected to get back.</typeparam>
    /// <returns>The db model which is returned.</returns>
    Task<T> GetOneById<T>(string tableName, int id);
}