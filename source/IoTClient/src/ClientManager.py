from tkinter.messagebox import NO
from LightClient import LightClient
from LightClientJson import LightClientJson

class ClientManager:
    def __init__(self, clients_file : str) -> None:
        self.__clients_file = clients_file
        self.__load_clients()

    def __load_clients(self) -> None:
        self.__clients = LightClientJson.load_clients(self.__clients_file)

    def __save_clients(self) -> None:
        LightClientJson.save_clients(self.__clients_file, self.__clients)

    def add_client(self, id : str, ip : str, port : int, gpio : int) -> None:
        client = LightClient(id)
        client.set_server_info(ip, port)
        client.set_gpio(gpio)
        self.__clients.append(client)
        self.__save_clients()
    
    def get_clients(self) -> list[LightClient]:
        return self.__clients

    def set_client_gpio(self, index : int, gpio : int) -> None:
        if index < 0 or index >= len(self.__clients): return
        self.__clients[index].set_gpio(gpio)

    def toggle_client(self, index : int) -> None:
        if index < 0 or index >= len(self.__clients): return
        if self.__clients[index].get_running():
            self.__clients[index].stop()
        else:
            self.__clients[index].run()

    def client_status(self, index : int) -> str:
        if index < 0 or index >= len(self.__clients): return ''
        c = self.__clients[index]
        return f'[{c.get_running()}] [{c.get_device_id()}] [{c.get_gpio()}]'


    

