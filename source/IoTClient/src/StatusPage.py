from calendar import c
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

        self.__statusManager = statusManager
    
    def _clear_console(self) -> None:
        return super()._clear_console()

    def __change_status(self) -> None:
        statusType : StatusType = StatusType.Unknown
        while statusType == statusType.Unknown:
            self._clear_console()
            print(self.__statusManager._get_current_str_of_status())
            print("Select status: ")
            for name, member in StatusType.__members__.items():
                print("{}: {}".format(member.value, name))
            inputStatus = input("Input new status id: ")
            statusType = self.__statusManager._convert_value_to_status(inputStatus)    
        
        self._clear_console()
        self.__statusManager._change_status(statusType)

    def __show_status(self):
        print(self.__statusManager._get_current_str_of_status())
        input("Press enter to proceed")

    def __create_broker_connection(self) -> None:
        if not self.__statusManager._is_running():
            print("Creating Connection")
            name = input("device id: ")
            server = input("ip: ")
            port = input("port: ")
            self.__statusManager._add_broker(name, server, port)
        

    def _show_controls(self) -> None:
        """Ui to show controls."""
        print("S - Change status")
        print("P - Publish status")
        print("C - Connect to broker")
        print("G - Get current status")
        print("L - Go to logging")
        print("------------------------------")

    def _on_key_pressed(self, k : str) -> None:
        """The callback for when a key has been pressed
        main logic

        Args:
            key (str): The key which was pressed.
        """
        if k == "l":
            BasePage.change_page("logging_page")
        if k == "s":
            self.__change_status()
        if k == "p":
            self.__statusManager._change_status_publish()
        if k == "c":
            self.__create_broker_connection()
        if k == "g":
            self.__show_status()
