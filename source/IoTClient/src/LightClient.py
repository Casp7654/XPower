from __future__ import annotations
from os import stat
import paho.mqtt.client as mqtt
from gpiozero import LED
import json

class LedCommandPackage:
    def __init__(self, device_id : str, should_turn_on : bool) -> None:
        self.device_id = device_id
        self.should_turn_on = should_turn_on

    @staticmethod
    def convert(json_data : str) -> LedCommandPackage:
        json_obj = json.loads(json_data)
        return LedCommandPackage(json_obj["device_id"], json_obj["should_turn_on"])
        

class LedStatusPackage:
    def __init__(self, device_id : str, is_turned_on : bool) -> None:
        self.device_id = device_id
        self.is_turned_on = is_turned_on

    @staticmethod
    def convert(package : LedStatusPackage) -> str:
        return json.dumps({ "device_id": package.device_id, "is_turned_on" : package.is_turned_on })
          

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
        self.__gpio = gpio

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
        self.__client.connect(self.__ip, self.__port, self.__keep_alive)
        self.__client.loop_start()
        self.__is_running = True

    def stop(self) -> None:
        self.__client.loop_stop()
        self.__is_running = False

class LightClientJson(json.JSONEncoder):
    def default(self, client):
        return {
            "client_id": client.get_device_id(),
            "ip": client.get_ip(),
            "port": client.get_port(),
            "gpio": client.get_gpio() 
        }

    @staticmethod
    def from_json(json_dict : dict) -> LightClient:
        client = LightClient(json_dict["client_id"])
        client.set_server_info(json_dict["ip"], json_dict["port"])
        client.set_gpio(json_dict["gpio"])
        return client