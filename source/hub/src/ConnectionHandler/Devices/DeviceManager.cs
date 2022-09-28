using System.Collections.Generic;

class DeviceManager : IDeviceManager
{
    List<Device> devices = new List<Device>()
    {
        new Device() { ClientId = "device1", StatusId = DeviceStatusType.TurnedOff },
        new Device() { ClientId = "device2", StatusId = DeviceStatusType.TurnedOn },
        new Device() { ClientId = "device3", StatusId = DeviceStatusType.TurnedOn },
        new Device() { ClientId = "device4", StatusId = DeviceStatusType.TurnedOn },
        new Device() { ClientId = "device5", StatusId = DeviceStatusType.ConnectedToHub },
        new Device() { ClientId = "device6", StatusId = DeviceStatusType.ConnectedToHub },
    };

    public List<Device> GetDevices()
    {
        return devices;
    }
}
