from tokenize import Number
from BasePage import BasePage, backcolors
from StatusManager import StatusManager
from StatusType import StatusType
from readchar import key

class StatusPage(BasePage):
    def __init__(self, statusManager : StatusManager) -> None:
        """The constructor of the status page.

        Args:
            statusManager (StatusManager): The manager to hold status
        """
        self.__cursor_pos = 0
        self.__current_page = self
        self.__statusManager = statusManager
    
    def _clear_console(self) -> None:
        return super()._clear_console()

    def __change_status(self) -> None:
        statusType : StatusType = StatusType.Unknown
        while statusType == statusType.Unknown:
            self._clear_console()
            print("Current status: {}-{}".format(statusType.value, statusType.name))
            print("Select status: ")
            for name, member in StatusType.__members__.items():
                print("{}: {}".format(member.value, name))
            status = input("status id: ")
            statusType = self.__statusManager.convert_value_to_status(status)    
        
        self._clear_console()
        self.__statusManager._change_status(statusType)
        print("Changed status to: {}-{}".format(statusType.value, statusType.name))

    def _show_page(self) -> None:
        if not self.__statusManager.is_running():
            status = self.__statusManager.StatusID
            print("Current status: {}-{}".format(status.value, status.name))
            self.__create_client()
            self.__change_status()

    def __create_client(self) -> None:
        name = input("device id: ")
        server = input("ip: ")
        port = input("port: ")
        self.__statusManager._add_client(name, server, port)

    def _on_key_pressed(self, k : str) -> None:
        """The callback for when a key has been pressed
        main logic

        Args:
            key (str): The key which was pressed.
        """
        if k == "l":
            BasePage.change_page("logging_page")