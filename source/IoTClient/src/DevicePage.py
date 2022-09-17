from ClientManager import ClientManager
from BasePage import BasePage, backcolors

class DevicePage(BasePage):
    def __init__(self, clientManager : ClientManager) -> None:
        """The constructor of the device page.

        Args:
            clientManager (ClientManager): The manager to hold clients
        """
        self.__cursor_pos = 0
        self.__clientManager = clientManager

    def __create_client(self) -> None:
        """Ui to create a client"""
        name = input("device id: ")
        server = input("ip: ")
        port = input("port: ")
        gpio = input("gpio: ")
        self.__clientManager.add_client(name, server, port, gpio)

    def _show_controls(self) -> None:
        """Ui to show controls."""
        print("W S - Up / Down in selection")
        print("Space - Turn On / Off")
        print("A D - Increase / Decrease pin")
        print("CTRL - Create new client")
        print("O - Removes selected client")
        print("------------------------------")

    def _show_page(self) -> None:
        """Ui for The main page content """
        clients = self.__clientManager.get_clients()
        print("[Running] [Name] [Pin]")
        for idx, c in enumerate(clients):
            dev_str = self.__clientManager.client_status(idx)
            if (idx == self.__cursor_pos):
                dev_str = backcolors.OKBLUE + dev_str + backcolors.ENDC
            print(dev_str)

    def _on_key_pressed(self, key : str) -> None:
        """The callback for when a key has been pressed
        main logic

        Args:
            key (str): The key which was pressed.
        """
        if key == "w":
            self.__cursor_pos -= 1
        elif key == "s":
            self.__cursor_pos += 1
        elif key == "space":
            self.__clientManager.toggle_client(self.__cursor_pos)
        elif key == "ctrl":
            self.__create_client()
        elif key == 'o':
            self.__clientManager.remove_client(self.__cursor_pos)
        elif key == "a":
            self.__clientManager.decrease_client_gpio(self.__cursor_pos)
        elif key == "d":
            self.__clientManager.increase_client_gpio(self.__cursor_pos)