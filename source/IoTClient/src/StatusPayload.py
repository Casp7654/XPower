from StatusType import StatusType

class StatusPayload():
    StatusID : StatusType

    def __init__(self, statusID : StatusType) -> None:
        self.StatusID = statusID