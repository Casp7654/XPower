from __future__ import annotations
import paho.mqtt.client as mqtt
from gpiozero import LED
          

class LightClient:
    def __init__(self, client_id : str) -> None:
        """Creates the lightclient with a client id

        Args:
            client_id (str): The device id / client id used in the mqtt connection
        """
        self.__client_id = client_id
        self.__client = mqtt.Client(client_id=self.__client_id, clean_session=True, userdata=None, protocol=mqtt.MQTTv311, transport="tcp")
        self.__client.on_connect = self.__on_connect
        self.__topic_name = "Led"
        self.__is_running = False

    def __on_connect(self, client : mqtt.Client, userdata : any, flags : int, rc : int) -> None:
        """Called when the client connects to the broker

        Args:
            client (mqtt.Client): The current client connected.
            userdata (any): The data which is defined by the user before going into the method
            flags (int): MQTT connection flags
            rc (int): The connection result.
        """
        client.subscribe(self.__topic_name)

    def __on_message(self, client : mqtt.Client, userdata : any, msg : mqtt.MQTTMessage) -> None:
        pass

    def set_server_info(self, ip : str, port : int) -> None:
        """Sets the server info for the client, for settings to be in effect. stop then start the server.

        Args:
            ip (str): The ip to connect to
            port (int): The port which should be used to connect to
        """
        self.__ip = ip
        self.__port = port
        self.__keep_alive = 60

    def set_gpio(self, gpio : int) -> None:
        """Set the gpio which the client should interact with

        Args:
            gpio (int): The number pin. ref: https://gpiozero.readthedocs.io/en/stable/_images/pin_layout.svg
        """
        gpio = int(gpio)
        self.__gpio = gpio if gpio > 0 else 0 # only assign value if bigger than 0

    def get_device_id(self) -> str:
        """
        Returns:
            str: returns the devices current device id
        """
        return self.__client_id

    def get_gpio(self) -> int:
        """
        Returns:
            int: returns the devices current gpio
        """
        return self.__gpio

    def get_running(self) -> bool:
        """_summary_

        Returns:
            bool: whether the client is running / connected
        """
        return self.__is_running

    def get_ip(self) -> str:
        """
        Returns:
            str: returns the clients current set ip
        """
        return self.__ip

    def get_port(self) -> int:
        """
        Returns:
            int: returns the port for the current device
        """
        return self.__port
        
    def run(self) -> None:
        """ Connects to the server, then starts a new thread for looping network data."""
        self.__client.connect(self.__ip, int(self.__port), self.__keep_alive)
        self.__client.loop_start()
        self.__is_running = True

    def stop(self) -> None:
        """Stops the current client, by disconnecting from the server."""
        self.__client.loop_stop()
        self.__is_running = False