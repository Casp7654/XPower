from StatusType import StatusType
from StatusType import DeviceType

class Device:
    def __init__(self, clientId : str, statusId : StatusType, typeId : DeviceType, macAdress : str) -> None:
        self.ClientId : str = clientId
        self.StatusId : StatusType = statusId
        self.TypeId : DeviceType = typeId
        self.MacAddress : str = macAdress