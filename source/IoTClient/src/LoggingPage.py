from ConsoleLogger import ConsoleLogger
from BasePage import BasePage

class LoggingPage(BasePage):
    def __init__(self, logger : ConsoleLogger) -> None:
        self.__logger = logger


    def _show_controls(self) -> None:
        """Ui to show controls."""
        print("D - Go to device page")
        print("------------------------------")

    def _show_page(self) -> None:
        """Ui for The main page content """
        logs = self.__logger.get_logs()
        for log in logs:
            str_time = log.get_time().strftime("%H:%M:%S")
            print(f"[{str_time}] [{log.get_type()}] : {log.get_message()}")
        

    def _on_key_pressed(self, key : str) -> None:
        """The callback for when a key has been pressed
        main logic

        Args:
            key (str): The key which was pressed.
        """

        if key == "d":
            BasePage.change_page("device_page")
        