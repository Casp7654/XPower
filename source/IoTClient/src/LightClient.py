from __future__ import annotations
import paho.mqtt.client as mqtt
from gpiozero import LED
          

class LightClient:
    def __init__(self, client_id : str) -> None:
        self.__client_id = client_id
        self.__client = mqtt.Client(client_id=self.__client_id, clean_session=True, userdata=None, protocol=mqtt.MQTTv311, transport="tcp")
        self.__client.on_connect = self.__on_connect
        self.__topic_name = "Led"
        self.__is_running = False

    def __on_connect(self, client : mqtt.Client, userdata : any, flags : int, rc : int) -> None:
        client.subscribe(self.__topic_name)

    def __on_message(self, client : mqtt.Client, userdata : any, msg : mqtt.MQTTMessage) -> None:
        pass

    def set_server_info(self, ip : str, port : int) -> None:
        self.__ip = ip
        self.__port = port
        self.__keep_alive = 60

    def set_gpio(self, gpio : int) -> None:
        gpio = int(gpio)
        self.__gpio = gpio if gpio > 0 else 0 # only assign value if bigger than 0

    def get_device_id(self) -> str:
        return self.__client_id

    def get_gpio(self) -> int:
        return self.__gpio

    def get_running(self) -> bool:
        return self.__is_running

    def get_ip(self) -> str:
        return self.__ip

    def get_port(self) -> int:
        return self.__port
        
    def run(self) -> None:
        self.__client.connect(self.__ip, int(self.__port), self.__keep_alive)
        self.__client.loop_start()
        self.__is_running = True

    def stop(self) -> None:
        self.__client.loop_stop()
        self.__is_running = False