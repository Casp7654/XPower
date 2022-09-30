using System.Collections.Generic;

class DeviceManager : IDeviceManager
{
    List<Device> mockDevices = new List<Device>()
    {
        new Device() { ClientId = "device2", StatusId = DeviceStatusType.TurnedOff, MacAdress = "faddd23f-631b-4f4a-be23-20547d84d09d", TypeId = DeviceType.Socket },
        new Device() { ClientId = "device3", StatusId = DeviceStatusType.TurnedOff, MacAdress = "832dea19-4ddd-4ced-8ba6-4e415db37629", TypeId = DeviceType.Socket },
        new Device() { ClientId = "device4", StatusId = DeviceStatusType.TurnedOff, MacAdress = "01562acf-0b84-40eb-b997-e90c5e901643", TypeId = DeviceType.Socket },
        new Device() { ClientId = "device5", StatusId = DeviceStatusType.ConnectedToHub, MacAdress = "8ac91bbd-1143-45f9-bd2e-ab4037d50b0f", TypeId = DeviceType.Socket },
        new Device() { ClientId = "device6", StatusId = DeviceStatusType.ConnectedToHub, MacAdress = "1c495e2a-ece6-4c69-a3eb-7d60c81ec99a", TypeId = DeviceType.Socket },
    };

    /// <summary>
    /// Gets connected devices that are currently offline
    /// </summary>
    public List<Device> GetDevices()
    {
        return mockDevices;
    }

    /// <summary>
    /// Gets status of connected devices that are offline
    /// </summary>
    public List<DeviceStatusResponse> GetDeviceStatusResponses()
    {
        var mockDevices = GetDevices();
        List<DeviceStatusResponse> deviceResponse = new ();
        
        for(int i = 0; i < mockDevices.Count; i++)
        {
            deviceResponse.Add(new DeviceStatusResponse(){
                Device = mockDevices[i]
            });
        }

        // Add socket data to 2 devices
        deviceResponse[2].Data = new SocketData() { TurnedOn = true };
        deviceResponse[3].Data = new SocketData() { TurnedOn = false };

        return deviceResponse;        
    }
}
