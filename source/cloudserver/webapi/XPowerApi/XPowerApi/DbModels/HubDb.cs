using XPowerApi.Models.HubModels;

namespace XPowerApi.DbModels;

public class HubDb
{
    public string id { get; set; }
    
    public string name { get; set; }

    public string mac { get; set; }
    
    public string private_addr { get; set; }
    
    public string public_addr { get; set; }

    public Hub ConvertToHub()
    {
        return new Hub
        {
            Id = int.Parse(id.Split(':')[1]),
            Name = name,
            Mac = mac,
            PrivateAddress = private_addr,
            PublicAddress = public_addr
        };
    }
}