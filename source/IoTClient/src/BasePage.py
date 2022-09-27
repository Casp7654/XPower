from __future__ import annotations
import os
from readchar import readkey, key
from abc import abstractmethod

class backcolors:
    """Background colors for the terminal"""
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
    __current_page : BasePage = None
    __registered_pages = {}

    @staticmethod
    def register_pages(pageDict):
        """Registers classes by dictionary

        Args:
            pageDict (_type_): The dictionary with pages related.
        """
        BasePage.__registered_pages = pageDict

    @staticmethod
    def change_page(page : str) -> None:
        """Changes the current page to the one given in string

        Args:
            page (str): The page name to change to
        """
        new_page = BasePage.__registered_pages.get(page)
        if new_page:
            BasePage.__current_page = new_page

    @staticmethod
    def get_page() -> BasePage:
        """
        Returns:
            BasePage: The current page
        """
        return BasePage.__current_page

    def _clear_console(self) -> None:
        """Used to clear the console both linux and windows"""
        if (os.name == "posix"):
            os.system("clear")
        else:
            os.system("cls")

    def __key_press(self) -> str:
        """Waits for key press.

        Returns:
            str: The key which was pressed.
        """
        return readkey()

    @abstractmethod
    def _show_controls(self) -> None:
        """ For showing controls on the page."""
        pass

    @abstractmethod
    def _show_page(self) -> None:
        """For showing the main content / page"""
        pass

    @abstractmethod
    def _on_key_pressed(self, key : str) -> None:
        """For when a key has been pressed

        Args:
            key (str): The key which was pressed.
        """
        pass

    def show_page(self) -> None:
        """Clears earlier content and shows current page."""
        self._clear_console()
        print(backcolors.OKCYAN, end="")
        self._show_controls()
        print(backcolors.ENDC, end="")
        self._show_page()

    def wait_for_key(self) -> None:
        """Called when waiting for key and calling key callback."""
        key = self.__key_press()
        self._on_key_pressed(key)