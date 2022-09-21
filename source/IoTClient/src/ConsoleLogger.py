from datetime import datetime

class LogEntry:
    def __init__(self, type : str, msg : str) -> None:
        self.__type = type
        self.__message = msg
        self.__date_time = datetime.now()
    
    def get_time(self) -> datetime:
        return self.__date_time

    def get_type(self) -> str:
        return self.__type 

    def get_message(self) -> str:
        return self.__message 

class ConsoleLogger:
    def __init__(self, name : str) -> None:
        self.__name = name
        self.__logs = []

    def __add_log(self, type : str, msg : str) -> None:
        """Adds a log with a type and a message

        Args:
            type (str): The type of log to add
            msg (str): The message to add
        """
        entry = LogEntry(type, msg)
        self.__logs.append(entry)

    def info(self, msg : str) -> None:
        """Logs the given message with time and the type as info

        Args:
            msg (str): The message to log
        """
        self.__add_log("info", msg)

    def warning(self, msg : str) -> None:
        """Logs the given message with time and the type as warning

        Args:
            msg (str): The message to log
        """
        self.__add_log("warning", msg)

    def error(self, msg : str) -> None:
        """Logs the given message with time and the type as error

        Args:
            msg (str): The message to log
        """
        self.__add_log("error", msg)


    def get_name(self) -> str:
        """
        Returns:
            str: The name of the console logger
        """
        return self.__name

    def get_logs(self) -> list[LogEntry]:
        """
        Returns:
            list[LogEntry]: All the logs in the logger
        """
        return self.__logs