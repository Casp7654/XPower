using System.Collections.Generic;

class DeviceManager : IDeviceManager
{
    List<Device> devices = new List<Device>()
    {
        new Device() { ClientID = "device1", Status = DeviceStatusType.TurnedOff },
        new Device() { ClientID = "device2", Status = DeviceStatusType.TurnedOn },
        new Device() { ClientID = "device3", Status = DeviceStatusType.TurnedOn },
        new Device() { ClientID = "device4", Status = DeviceStatusType.TurnedOn },
        new Device() { ClientID = "device5", Status = DeviceStatusType.ConnectedToHub },
        new Device() { ClientID = "device6", Status = DeviceStatusType.ConnectedToHub },
    };

    public List<Device> GetDevices()
    {
        return devices;
    }
}
