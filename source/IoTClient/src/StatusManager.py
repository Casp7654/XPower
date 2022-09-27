from StatusType import StatusType
from StatusPayload import StatusPayload
import paho.mqtt.client as mqtt
import json
from ConsoleLogger import ConsoleLogger

class StatusManager:
    def __init__(self, logger : ConsoleLogger) -> None:
        self.StatusID : StatusType = StatusType.Unknown
        self.__logger = logger   
        self.__is_running = False 

    def _change_status(self, statusId : StatusType) -> None:
        self.StatusID = statusId
        payLoad : StatusPayload = StatusPayload(self.StatusID)
        jsonPayload = json.dumps(payLoad.__dict__)
        self.__client.publish(f"Status/{self.__client_id}", jsonPayload)

    def convert_value_to_status(self, value):
        try:
            # if provided value is a int
            return StatusType(value)
        except:
            try:
                # if provided value is a string
                return StatusType[value]
            except:
                return StatusType.Unknown

    def _add_client(self, deviceID : str, ip : str, port : int):
        self.__client_id = f"mqtt_{deviceID}"
        self.__ip = ip
        self.__port = port
        self.__keep_alive = 60
        self.__client = mqtt.Client(client_id=self.__client_id, clean_session=True, userdata=None, protocol=mqtt.MQTTv311, transport="tcp")
        self.__client.on_connect = self.__on_connect
        self.__client.on_message = self.__on_message
        self.__topic_name = f"Status/{self.__client_id}"
        self.__set_logging_events()
        self.__client.connect(self.__ip, int(self.__port), self.__keep_alive)
        self.__client.loop_start()
        self.__is_running = True 

    def is_running(self):
        return self.__is_running;

    def __set_logging_events(self) -> None:
        """Sets logging for the clients events

        Args:
            client (LightClient): _description_
        """
        self.on_connected = lambda id, ip, port: self.__logger.info(f"{id} -> Connected to {ip}:{port}")
        self.on_subscribed = lambda id, topic: self.__logger.info(f"{id} -> subscribed to {topic}")
        self.on_message_received = lambda id, topic, payload: self.__logger.info(f"{id} -> received message {topic}:{payload}")
        self.on_published = lambda id, topic, payload: self.__logger.info(f"{id} -> publish send {topic}:{payload}")


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

        self.__subscribe(self.__topic_name)

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
        appData = json.loads(msg.payload)
        status = appData["StatusID"]
        print(f"status changed to {status}")        

        if (self.on_message_received):
            self.on_message_received(self.__client_id, msg.topic, msg.payload)

