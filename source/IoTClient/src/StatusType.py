from enum import Enum
class StatusType(int, Enum):
    Unknown = 0
    TurnOff = 1
    TurnOn = 2
    ConnectedToHub = 3

class DeviceType(int, Enum):
    Hub = 0
    Socket = 1