using System.Collections.Generic;

class DeviceManager : IDeviceManager
{
    List<Device> devices = new List<Device>()
    {
        new Device() { ClientId = "device1", StatusId = DeviceStatusType.TurnedOff, MacAdress = "ba750537-3ddd-4b58-a97c-eb3d363b763a", TypeId = DeviceType.Socket },
        new Device() { ClientId = "device2", StatusId = DeviceStatusType.TurnedOn, MacAdress = "faddd23f-631b-4f4a-be23-20547d84d09d", TypeId = DeviceType.Socket },
        new Device() { ClientId = "device3", StatusId = DeviceStatusType.TurnedOn, MacAdress = "832dea19-4ddd-4ced-8ba6-4e415db37629", TypeId = DeviceType.Socket },
        new Device() { ClientId = "device4", StatusId = DeviceStatusType.TurnedOn, MacAdress = "01562acf-0b84-40eb-b997-e90c5e901643", TypeId = DeviceType.Socket },
        new Device() { ClientId = "device5", StatusId = DeviceStatusType.ConnectedToHub, MacAdress = "8ac91bbd-1143-45f9-bd2e-ab4037d50b0f", TypeId = DeviceType.Socket },
        new Device() { ClientId = "device6", StatusId = DeviceStatusType.ConnectedToHub, MacAdress = "1c495e2a-ece6-4c69-a3eb-7d60c81ec99a", TypeId = DeviceType.Socket },
    };

    public List<Device> GetDevices()
    {
        return devices;
    }

    public List<DeviceStatusResponse> GetDeviceStatusResponses()
    {
        var devices = GetDevices();
        List<DeviceStatusResponse> deviceResponse = new ();
        
        for(int i = 0; i < devices.Count; i++)
        {
            deviceResponse.Add(new DeviceStatusResponse(){
                Device = devices[i]
            });
        }

        deviceResponse[3].Data = new SocketData() { Gpio = 3, Volt = 5 };
        deviceResponse[4].Data = new SocketData() { Gpio = 4, Volt = 3.5 };

        return deviceResponse;        
    }
}
