from StatusType import StatusType

class StatusPayload():
    def __init__(self, clientID : str, statusID : StatusType) -> None:
        self.StatusId : StatusType= statusID
        self.ClientId : str = clientID