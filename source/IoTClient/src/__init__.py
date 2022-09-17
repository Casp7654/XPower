from time import sleep
import LightClient as cl
import os
import keyboard
import json

from LightClient import LightClient, LightClientJson

client_save_file = "clients.json"
clients = []
cursor_pos = 0
current_page_func = None

class bcolors:
    HEADER = '\033[95m'
    OKBLUE = '\033[94m'
    OKCYAN = '\033[96m'
    OKGREEN = '\033[92m'
    WARNING = '\033[93m'
    FAIL = '\033[91m'
    ENDC = '\033[0m'
    BOLD = '\033[1m'
    UNDERLINE = '\033[4m'

def clear_console() -> None:
    if (os.name == "posix"):
        os.system("clear")
    else:
        os.system("cls")

def key_press() -> str:
    return keyboard.read_key()

def show_controls() -> None:
    print("W S - Up / Down in selection")
    print("Space - Turn On / Off")
    print("A D - Increase / Decrease pin")
    print("CTRL - Create new client")
    print("------------------------------")

def show_front_page() -> None:
    global cursor_pos
    global clients
    print("[Running] [Name] [Pin]")
    for idx, c in enumerate(clients):
        dev_str = f'[{c.get_running()}] [{c.get_device_id()}] [{c.get_gpio()}]'
        if (idx == cursor_pos):
            dev_str = bcolors.OKBLUE + dev_str + bcolors.ENDC
        print(dev_str)

    interaction = key_press()
    print(interaction)
    if interaction == "w":
        cursor_pos -= 1
    elif interaction == "s":
        cursor_pos += 1
    elif interaction == "space":
        cl = clients[cursor_pos]
        if (cl.get_running()):
            cl.stop()
        else:
            cl.run()
    elif interaction == "ctrl":
        show_create_client()

def show_create_client() -> None:
    name = input("device id: ")
    server = input("ip: ")
    port = input("port: ")
    gpio = input("gpio: ")

    c = cl.LightClient(name)
    c.set_server_info(server, port)
    c.set_gpio(gpio)
    clients.append(c)
    save_clients()

def save_clients() -> None:
    global clients
    json_str = json.dumps(clients, cls = LightClientJson)

    with open(client_save_file, 'w') as f:
        f.write(json_str)

def load_clients() -> list[LightClient]:
    json_str = ''
    cs = []

    try:
        with open(client_save_file, 'r') as f:
            json_str = f.read()
    except:
        return cs

    if (json_str == '') : return cs

    for c in json.loads(json_str):
        cs.append(LightClientJson.from_json(c))

    return cs


## Main
def main():
    global clients
    clients = load_clients()

    current_page_func = show_front_page
    while(1):
        clear_console()
        show_controls()
        current_page_func()
        sleep(100/1000)

if __name__ == "__main__":
    main()