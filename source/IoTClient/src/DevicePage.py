from ClientManager import ClientManager
from BasePage import BasePage, bcolors

class DevicePage(BasePage):
    def __init__(self, clientManager : ClientManager) -> None:
        self.__cursor_pos = 0
        self.__clientManager = clientManager

    def __create_client(self) -> None:
        name = input("device id: ")
        server = input("ip: ")
        port = input("port: ")
        gpio = input("gpio: ")
        self.__clientManager.add_client(name, server, port, gpio)

    def _show_controls(self) -> None:
        print("W S - Up / Down in selection")
        print("Space - Turn On / Off")
        print("A D - Increase / Decrease pin")
        print("CTRL - Create new client")
        print("------------------------------")

    def _show_page(self) -> None:
        clients = self.__clientManager.get_clients()
        print("[Running] [Name] [Pin]")
        for idx, c in enumerate(clients):
            dev_str = self.__clientManager.client_status(idx)
            if (idx == self.__cursor_pos):
                dev_str = bcolors.OKBLUE + dev_str + bcolors.ENDC
            print(dev_str)

    def _on_key_pressed(self, key : str) -> None:
        if key == "w":
            self.__cursor_pos -= 1
        elif key == "s":
            self.__cursor_pos += 1
        elif key == "space":
            self.__clientManager.toggle_client(self.__cursor_pos)
        elif key == "ctrl":
            self.__create_client()