from Device import Device


class DeviceStatusResponse():

    def __init__(self, device : Device, data) -> None:
        self.Device : Device = device
        self.Data = data