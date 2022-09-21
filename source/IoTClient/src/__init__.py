from time import sleep
from DevicePage import DevicePage
from ClientManager import ClientManager
from ConsoleLogger import ConsoleLogger
from BasePage import BasePage
from LoggingPage import LoggingPage

## Main
def main():
    logger = ConsoleLogger("ClientLogger")
    clientManager = ClientManager("clients.json", logger)
    
    devPage = DevicePage(clientManager)
    loggerPage = LoggingPage(logger)

    BasePage.register_pages({
        "device_page": devPage,
        "logging_page": loggerPage
    })

    BasePage.change_page("device_page")

    while(1):
        page = BasePage.get_page()
        page.show_page()
        page.wait_for_key()
        sleep(100/1000)

if __name__ == "__main__":
    main()