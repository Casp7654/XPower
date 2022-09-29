using System.Collections.Generic;

public interface IDeviceManager
{
    public List<Device> GetDevices();    
    public List<DeviceStatusResponse> GetDeviceStatusResponses();
}