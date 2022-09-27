from enum import Enum
class StatusType(str, Enum):
    Unknown = 0
    TurnOff = 1
    TurnOn = 2
    ConnectedToHub = 3