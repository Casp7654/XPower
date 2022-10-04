from time import sleep
from DevicePage import DevicePage
from ClientManager import ClientManager
from ConsoleLogger import ConsoleLogger
from BasePage import BasePage
from LoggingPage import LoggingPage
from StatusManager import StatusManager
from StatusPage import StatusPage

## Main
def main():
    logger = ConsoleLogger("ClientLogger")
    clientManager = ClientManager("clients.json", logger)
    statusManager = StatusManager(logger)

    devPage = DevicePage(clientManager)
    statusPage = StatusPage(statusManager)
    loggerPage = LoggingPage(logger)

    BasePage.register_pages({
        "device_page": devPage,
        "status_page" : statusPage,
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