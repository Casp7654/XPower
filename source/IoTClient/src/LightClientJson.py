from LightClient import LightClient
import json

class LightClientJson(json.JSONEncoder):
    def default(self, client):
        """Used in json encoder from client to json

        Args:
            client (LightClient): The client to convert

        Returns:
            Json: 
        """
        return {
            "client_id": client.get_device_id(),
            "ip": client.get_ip(),
            "port": client.get_port(),
            "gpio": client.get_gpio() 
        }

    @staticmethod
    def from_json(json_dict : dict) -> LightClient:
        """Used to convert from json dictionary to ligthclient

        Args:
            json_dict (dict): Json dictionary object

        Returns:
            LightClient: The client converted from the json dictionary
        """
        client = LightClient(json_dict["client_id"])
        client.set_server_info(json_dict["ip"], json_dict["port"])
        client.set_gpio(json_dict["gpio"])
        return client

    @staticmethod
    def save_clients(filename : str, clients : list[LightClient]) -> None:
        """ Save the clients given into the file based upon json

        Args:
            filename (str): The file where the clients should reside in.
            clients (list[LightClient]): The clients to save.
        """
        json_str = json.dumps(clients, cls = LightClientJson)

        with open(filename, 'w') as f:
            f.write(json_str)

    @staticmethod
    def load_clients(filename : str) -> list[LightClient]:
        """Reads the lightclients from the given json file

        Args:
            filename (str): The file to read the clients from

        Returns:
            list[LightClient]: The clients converted from the json file
        """
        json_str = ''
        cs = []

        try:
            with open(filename, 'r') as f:
                json_str = f.read()
        except:
            return cs

        if (json_str == '') : return cs

        for c in json.loads(json_str):
            cs.append(LightClientJson.from_json(c))

        return cs