public class DeviceManagerShould
{
    List<Device> GetDevices()
    {
        return  new List<Device>
        {           
            new Device() { ClientId = "device1", StatusId = DeviceStatusType.TurnedOn, MacAdress = "4ec4e5cd-bc54-46a0-bd80-c759e73f2296", TypeId = DeviceType.Socket },
            new Device() { ClientId = "device2", StatusId = DeviceStatusType.ConnectedToHub, MacAdress = "a9526210-2add-4fcb-ad0d-2991ddc693f7", TypeId = DeviceType.Socket },
            new Device() { ClientId = "device3", StatusId = DeviceStatusType.ConnectedToHub, MacAdress = "43e3b61c-eb6c-411a-bfc8-52e71f93ba58", TypeId = DeviceType.Socket }
        };
    }

    List<DeviceStatusResponse> GetDeviceStatusResponses()
    {
        var devices = GetDevices();

        List<DeviceStatusResponse> deviceResponse = new ();
        for(int i = 0; i < devices.Count; i++)
        {
            deviceResponse.Add(new DeviceStatusResponse(){
                Device = devices[i]
            });
        }

        deviceResponse[1].Data = new SocketData() { TurnedOn = true };
        deviceResponse[2].Data = new SocketData() { TurnedOn = false };
        return deviceResponse;
    }

    [Fact]
    void DeviceManagerShould_ReturnDeviceSameAmount()
     {
        // Arrange
        var deviceManager = A.Fake<IDeviceManager>();
        
        List<Device> devices = GetDevices();
        
        A.CallTo(() => deviceManager.GetDevices()).Returns(devices);

        Assert.Equal(deviceManager.GetDevices().Count, devices.Count);
    }

    [Fact]
    void DeviceManagerShould_ReturnDeviceSameItems()
     {
        // Arrange
        var deviceManager = A.Fake<IDeviceManager>();
        
        List<Device> devices = GetDevices();
        
        A.CallTo(() => deviceManager.GetDevices()).Returns(devices);

        Assert.Equal(deviceManager.GetDevices(), devices);
    }

    [Fact]
    void DeviceManagerShould_ReturnStatusDevicesSameAmount()
     {
        // Arrange
        var deviceManager = A.Fake<IDeviceManager>();
        
        var devices = GetDevices();
        var deviceResponse = GetDeviceStatusResponses();
        

        A.CallTo(() => deviceManager.GetDevices()).Returns(devices);
        A.CallTo(() => deviceManager.GetDeviceStatusResponses()).Returns(deviceResponse);

        Assert.Equal(deviceManager.GetDeviceStatusResponses().Count, devices.Count);
    }

    [Fact]
    void DeviceManagerShould_ReturnStatusDevicesSameItems()
     {
        // Arrange
        var deviceManager = A.Fake<IDeviceManager>();
        
        var devices = GetDevices();
        var deviceResponse = GetDeviceStatusResponses();
        

        A.CallTo(() => deviceManager.GetDevices()).Returns(devices);
        A.CallTo(() => deviceManager.GetDeviceStatusResponses()).Returns(deviceResponse);

        Assert.Equal(deviceManager.GetDeviceStatusResponses(), deviceResponse);
    }
}