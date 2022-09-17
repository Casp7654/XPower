import os
import keyboard
from abc import abstractmethod

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

class BasePage:
    def __clear_console(self) -> None:
        if (os.name == "posix"):
            os.system("clear")
        else:
            os.system("cls")

    def __key_press(self) -> str:
        return keyboard.read_key()

    @abstractmethod
    def _show_controls(self) -> None:
        pass

    @abstractmethod
    def _show_page(self) -> None:
        pass

    @abstractmethod
    def _on_key_pressed(self, key : str) -> None:
        pass

    def show_page(self) -> None:
        self.__clear_console()
        self._show_controls()
        self._show_page()

    def wait_for_key(self) -> None:
        key = self.__key_press()
        self._on_key_pressed(key)