using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace XPowerApiTEST;

public class FakeConfiguration : IConfiguration
{
    private Dictionary<string, string> values;

    public FakeConfiguration()
    {
        values = new()
        {
            { "SurrealDB:ConnStr", "http://127.0.0.1:8000/" },
            { "SurrealDB:User", "root" },
            { "SurrealDB:Namespace", "root" },
            { "SurrealDB:Database", "root" },
        };
    }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        throw new NotImplementedException();
    }

    public IChangeToken GetReloadToken()
    {
        throw new NotImplementedException();
    }

    public IConfigurationSection GetSection(string key)
    {
        throw new NotImplementedException();
    }

    public string this[string key]
    {
        get { return this.values[key]; }
        set { this.values[key] = value; }
    }

}