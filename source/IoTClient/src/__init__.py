from time import sleep
import os
import keyboard

from ClientManager import ClientManager

class bcolors:
    HEADER = '\033[95m'
    OKBLUE = '\033[94m'
    OKCYAN = '\033[96m'
    OKGREEN = '\033[92m'
    WARNING = '\033[93m'
    FAIL = '\033[91m'
    ENDC = '\033[0m'
    BOLD = '\033[1m'
    UNDERLINE = '\033[4m'
    
class UIManager:
    def __init__(self) -> None:
        self.__cursor_pos = 0
        self.__clientManager = ClientManager("clients.json")

    def __clear_console(self) -> None:
        if (os.name == "posix"):
            os.system("clear")
        else:
            os.system("cls")

    def __key_press(self) -> str:
        return keyboard.read_key()

    def __device_page_interaction(self) -> None:
        interaction = self.__key_press()
        if interaction == "w":
            self.__cursor_pos -= 1
        elif interaction == "s":
            self.__cursor_pos += 1
        elif interaction == "space":
            self.__clientManager.toggle_client(self.__cursor_pos)
        elif interaction == "ctrl":
            self.__create_client()

    def __create_client(self) -> None:
        name = input("device id: ")
        server = input("ip: ")
        port = input("port: ")
        gpio = input("gpio: ")
        self.__clientManager.add_client(name, server, port, gpio)

    def load_page(self) -> None:
        clients = self.__clientManager.get_clients()
        print("[Running] [Name] [Pin]")
        for idx, c in enumerate(clients):
            dev_str = self.__clientManager.client_status(idx)
            if (idx == self.__cursor_pos):
                dev_str = bcolors.OKBLUE + dev_str + bcolors.ENDC
            print(dev_str)

        self.__device_page_interaction()

    def controls(self) -> None:
        print("W S - Up / Down in selection")
        print("Space - Turn On / Off")
        print("A D - Increase / Decrease pin")
        print("CTRL - Create new client")
        print("------------------------------")



## Main
def main():
    manager = UIManager()

    while(1):
        manager.controls()
        manager.load_page()
        sleep(100/1000)

if __name__ == "__main__":
    main()