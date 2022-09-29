using System.Collections.Generic;

interface IDeviceManager
{
    public List<Device> GetDevices();    
    public List<DeviceStatusResponse> GetDeviceStatusResponses();
}