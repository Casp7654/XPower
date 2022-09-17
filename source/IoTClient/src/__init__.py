import LightClient as cl

server_ip = "broker.emqx.io"
server_port = 1883
server_keep_alive = 60



## Main
def main():
    lightClient = cl.LightClient()
    lightClient.set_server_info(server_ip, server_port)
    lightClient.run()

if __name__ == "__main__":
    main()