from time import sleep
from DevicePage import DevicePage
from ClientManager import ClientManager

## Main
def main():
    clientManager = ClientManager("clients.json")
    page = DevicePage(clientManager)

    while(1):
        page.show_page()
        page.wait_for_key()
        sleep(100/1000)

if __name__ == "__main__":
    main()