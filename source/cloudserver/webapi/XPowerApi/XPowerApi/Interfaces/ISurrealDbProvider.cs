using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Interfaces;

public interface ISurrealDbProvider
{
    /// <summary>
    /// Retrieves surreal db result by executing the given sql string.
    /// </summary>
    /// <param name="sqlString">The string to execute.</param>
    /// <returns>A surreal db result</returns>
    Task<SurrealDbResult> MakeRawResult(string sqlString);

    /// <summary>
    /// Creates a new entry by tablename and the given data.
    /// data ex: key : value
    /// </summary>
    /// <param name="tableName">The name of the table to insert into</param>
    /// <param name="dataArray">The data to insert.</param>
    /// <typeparam name="T">The expected return type.</typeparam>
    /// <returns>The newly inserted result.</returns>
    Task<T> Create<T>(string tableName, Dictionary<string, string> dataArray) where T : new();

    /// <summary>
    /// Creates a relation between two ids and the name of the relation.
    /// </summary>
    /// <param name="fromId">The first relation id.</param>
    /// <param name="toId">The second relation id.</param>
    /// <param name="byName">The name of the relation.</param>
    /// <returns>The newly created relation object.</returns>
    Task<RelateObject> Relate(string fromId, string toId, string byName);

    /// <summary>
    /// Get the next id from the given table. Last id + 1
    /// </summary>
    /// <param name="tableName">The name of the table to get id from.</param>
    /// <returns>The next id which can be used.</returns>
    Task<int> GetNextId(string tableName);

    /// <summary>
    /// Get one entry by id.
    /// </summary>
    /// <param name="tableName">The table to fetch from.</param>
    /// <param name="id">The id to fetch.</param>
    /// <typeparam name="T">The expected result type.</typeparam>
    /// <returns>The result represented by the given type.</returns>
    Task<T> GetOneById<T>(string tableName, int id);

    /// <summary>
    /// Retrieves a relation between 2 ids
    /// </summary>
    /// <param name="subjectId">The id of the subject.</param>
    /// <param name="relationName">The name of the relation.</param>
    /// <param name="alias">The alias of the relation.</param>
    /// <returns>The relation object between the ids.</returns>
    Task<RelateObject> GetRelation(string subjectId, string relationName, string alias = "");

    /// <summary>
    /// Get object by joining tables.
    /// </summary>
    /// <param name="tableName">The wanted table</param>
    /// <param name="baseTable">The table to join onto.</param>
    /// <param name="targetId">The base tables id.</param>
    /// <typeparam name="T">The expected return type.</typeparam>
    /// <returns>A list of the expected types.</returns>
    Task<List<T>> GetOneFromInsideAnother<T>(string tableName, string baseTable, string targetId);

    /// <summary>
    /// Retrieves a single object from a many to many relation table by id.
    /// </summary>
    /// <param name="tableName">The table to query from.</param>
    /// <param name="baseTable">The joining table.</param>
    /// <param name="relationTable">The related table.</param>
    /// <param name="targetId">The id to fetch from.</param>
    /// <typeparam name="T">The expected type to return.</typeparam>
    /// <returns>A list of expected types.</returns>
    Task<List<T>> GetOneFromInsideARelation<T>(string tableName, string baseTable, string relationTable, string targetId);

    /// <summary>
    /// Retreives a entry by a field name and value.
    /// </summary>
    /// <param name="tableName">The table name to look up</param>
    /// <param name="field">The field in the table.</param>
    /// <param name="value">The value to look for</param>
    /// <typeparam name="T">The expected return type.</typeparam>
    /// <returns>The object matching the criterias.</returns>
    Task<T> GetOneByField<T>(string tableName, string field, string value);
}
