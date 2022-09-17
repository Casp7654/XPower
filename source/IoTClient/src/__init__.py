import paho.mqtt.client as mqtt

server_ip = "broker.emqx.io"
server_port = 1883
server_keep_alive = 60
mqtt_client = mqtt.Client()

## Client
def on_Connect(client, userdata, flags, rc):
    print("Connected")

    client.subscribe("socket")

def on_message(client, userdata, msg):
    print(msg.topic+" "+str(msg.payload))

def start_client(client):
    client.on_connect = on_Connect
    client.on_message = on_message

    client.connect(server_ip, server_port, server_keep_alive)

    client.loop_forever()


## Main
def main():
    start_client(mqtt_client)
    


if __name__ == "__main__":
    main()