using XPowerApi.Models.HomeGroupModels;

namespace XPowerApi.Models.UserModels;

public class UserGroup
{
    public int Id { get; set; }

    public HomeGroup HomeGroup { get; set; }
}