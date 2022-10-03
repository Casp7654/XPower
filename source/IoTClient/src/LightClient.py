from __future__ import annotations
from os import stat
import paho.mqtt.client as mqtt
from Device import Device
from DeviceStatusResponse import DeviceStatusResponse
from Led import Led
import json
from SocketData import SocketData
from StatusType import DeviceType, StatusType
          

class LightClient:
    def __init__(self, client_id : str) -> None:
        """Creates the lightclient with a client id

        Args:
            client_id (str): The device id / client id used in the mqtt connection
        """
        self.__client_id = client_id
        self.__client = mqtt.Client(client_id=self.__client_id, clean_session=True, userdata=None, protocol=mqtt.MQTTv311, transport="tcp")
        self.__client.on_connect = self.__on_connect
        self.__client.on_message = self.__on_message
        self.__is_running = False
        self.__gpio = Led(0)
        self.__device = Device(self.__client_id, StatusType.TurnOff, DeviceType.Socket, "MAC:ASD:GHJ:LKJ")

        self.on_connected = None
        self.on_subscribed = None
        self.on_message_received = None
        self.on_publish_message = None

    def __on_connect(self, client : mqtt.Client, userdata : any, flags : int, rc : int) -> None:
        """Called when the client connects to the broker

        Args:
            client (mqtt.Client): The current client connected.
            userdata (any): The data which is defined by the user before going into the method
            flags (int): MQTT connection flags
            rc (int): The connection result.
        """
        if (self.on_connected):
            self.on_connected(self.__client_id, self.__ip, self.__port)

        self.__subscribe(f"Led/{self.__client_id}")
        self.__subscribe("Led/All")
        self.__subscribe("StatusRequest/all")

    def __subscribe(self, topic_name : str) -> None:
        """Subscribes to the given topic name"""
        self.__client.subscribe(topic_name)

        if (self.on_subscribed):
            self.on_subscribed(self.__client_id, topic_name)

    def __on_message(self, client : mqtt.Client, userdata : any, msg : mqtt.MQTTMessage) -> None:
        """Called when the client recieves a message

        Args:
            client (mqtt.Client): The current client connected.
            userdata (any): The data which is defined by the user before going into the method
            msg (mqtt.MQTTMessage): The message recieved
        """
        if "StatusRequest" in msg.topic:
            self.publish_status()
        elif "Led" in msg.topic:
            appData = json.loads(msg.payload)
            if appData["cmd"] == "on":
                self.__gpio.set_state(True)
            elif appData["cmd"] == "off":
                self.__gpio.set_state(False)

        if (self.on_message_received):
            self.on_message_received(self.__client_id, msg.topic, msg.payload)
    
    def __on_publish(self, topic, message):
        """Called when the client publishes a message

        Args:
            client (_type_): the client publishing
            userdata (_type_): the user defined data
            mid (_type_): _description_
        """
        if self.on_publish_message:
            self.on_publish_message(self.__client_id, topic, message)

    def publish_status(self):
        """Publishes the current status of the device to the topic StatusResponse/All
        """
        socketData = SocketData(self.__gpio.get_state())
        statusDevice : DeviceStatusResponse = DeviceStatusResponse(self.__device.__dict__, socketData.__dict__)
        self.__on_publish("test", json.dumps(socketData.__dict__))

        payload = []   
        payload.append(statusDevice.__dict__)
        
        jsonPayload = json.dumps(payload)        
        self.__client.publish(f"StatusResponse/all", jsonPayload)
        self.__on_publish("StatusResponse/all", jsonPayload)

    def set_status(self, status : StatusType):
        """Sets the status of the device.

        Args:
            status (StatusType): The new status of the device
        """
        self.__device.StatusId = status
    
    def get_status(self) -> StatusType:
        return self.__device.StatusId

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
        gpio = gpio if gpio > 0 else 0 # only assign value if bigger than 0
        self.__gpio = Led(gpio)

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
        return self.__gpio.get_pin()

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
        self.publish_status()
        self.__is_running = True

    def stop(self) -> None:
        """Stops the current client, by disconnecting from the server."""
        self.__client.loop_stop()
        self.__is_running = False