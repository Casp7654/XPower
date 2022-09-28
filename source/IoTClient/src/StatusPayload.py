from StatusType import StatusType

class StatusPayload():
    def __init__(self, clientID : str, statusID : StatusType) -> None:
        self.StatusID : StatusType= statusID
        self.ClientID : str = clientID