using XPowerApi.Models.HomeGroupModels;

namespace XPowerApi.DbModels;

public class HomeGroupDb
{
    public string id { get; set; }
    
    public string name { get; set; }
        
    public HomeGroup ConvertToHomeGroup()
    {
        return new HomeGroup
        {
            Id = int.Parse(id.Split(':')[1]),
            Name = name,
        };
    }
}