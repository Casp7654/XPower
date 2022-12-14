from LightClient import LightClient
from LightClientJson import LightClientJson
from ConsoleLogger import ConsoleLogger
from StatusType import StatusType

class ClientManager:
    def __init__(self, clients_file : str, logger : ConsoleLogger) -> None:
        """Constructor for client manager

        Args:
            clients_file (str): The client file where clients should be loaded / saved
        """
        self.__clients_file = clients_file
        self.__logger = logger
        self.__load_clients()
        for c in self.__clients:
            self.__set_logging_events(c)

    def __load_clients(self) -> None:
        """Loads the clients from the clients_file"""
        self.__clients = LightClientJson.load_clients(self.__clients_file)

    def __save_clients(self) -> None:
        """Saves the current clients into the clients_file"""
        LightClientJson.save_clients(self.__clients_file, self.__clients)

    def __set_logging_events(self, client : LightClient) -> None:
        """Sets logging for the clients events

        Args:
            client (LightClient): _description_
        """
        client.on_connected = lambda id, ip, port: self.__logger.info(f"{id} -> Connected to {ip}:{port}")
        client.on_subscribed = lambda id, topic: self.__logger.info(f"{id} -> subscribed to {topic}")
        client.on_message_received = lambda id, topic, payload: self.__logger.info(f"{id} -> received message {topic}:{payload}")
        client.on_publish_message = lambda id, topic, payload: self.__logger.info(f"{id} -> published message {topic}:{payload}")

    def add_client(self, id : str, ip : str, port : int, gpio : int) -> None:
        """Adds a client to the list of current clients, and saves the clients.

        Args:
            id (str): The id of the device / device_id / client_id
            ip (str): The ip of the broker( server ) the client should connect to
            port (int): The port to use when connection to broker
            gpio (int): The gpio to control.
        """
        client = LightClient(id)
        client.set_server_info(ip, port)
        client.set_gpio(gpio)
        self.__set_logging_events(client)
        self.__clients.append(client)
        self.__save_clients()
        

    def remove_client(self, index : int) -> None:
        """Removes the client at the given index, and saves the client list

        Args:
            index (int): The index where the client should be removed.
        """
        if index < 0 or index >= len(self.__clients): return
        self.__clients.pop(index)
        self.__save_clients()
    
    def get_clients(self) -> list[LightClient]:
        """
        Returns:
            list[LightClient]: Returns all the current clients
        """
        return self.__clients

    def set_status(self, index: int, status : StatusType):
        """Sets new status for device and publishes the new result

        Args:
            index (int): The client index to change
            status (StatusType): The new status for the device
        """
        if index < 0 or index >= len(self.__clients): return
        cur = self.__clients[index]
        cur.set_status(status)
        old_val = cur.get_status()
        self.__logger.info(f"{cur.get_device_id()} -> status changed from {old_val}:{status}")
        cur.publish_status()
        self.__save_clients()

    def set_client_gpio(self, index : int, gpio : int) -> None:
        """Sets the clients gpio at the given index 
        and saves the clients

        Args:
            index (int): The index into the clients list
            gpio (int): The new value
        """
        if index < 0 or index >= len(self.__clients): return
        cur = self.__clients[index]
        old_val = cur.get_gpio()
        cur.set_gpio(gpio)
        self.__logger.info(f"{cur.get_device_id()} -> GPIO changed from {old_val}:{gpio}")
        self.__save_clients()

    def toggle_client(self, index : int) -> None:
        """Toggles the client to on / off at the given index.

        Args:
            index (int): The index into the clients list.
        """
        if index < 0 or index >= len(self.__clients): return
        if self.__clients[index].get_running():
            self.__clients[index].stop()
        else:
            self.__clients[index].run()

    def increase_client_gpio(self, index : int) -> None:
        """Increases the gpio of the client at the given index.

        Args:
            index (int): The index in the clients list
        """
        if index < 0 or index >= len(self.__clients): return
        cur_gpio = self.__clients[index].get_gpio()
        self.set_client_gpio(index, cur_gpio + 1)

    def decrease_client_gpio(self, index : int) -> None:
        """decreases the gpio of the client at the given index.

        Args:
            index (int): The index in the clients list
        """
        if index < 0 or index >= len(self.__clients): return
        cur_gpio = self.__clients[index].get_gpio()
        self.set_client_gpio(index, cur_gpio - 1)

    def client_status(self, index : int) -> str:
        """The client status at the given index in string format.
        [running] [device_id] [gpio]

        Args:
            index (int): The index into the clients list

        Returns:
            str: The client status in string format.
        """
        if index < 0 or index >= len(self.__clients): return ''
        c = self.__clients[index]
        return f'[{c.get_running()}] [{c.get_device_id()}] [{c.get_gpio()}] [{c.get_status().name}]'