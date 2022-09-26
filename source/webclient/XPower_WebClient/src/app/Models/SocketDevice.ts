import { IoTDevice } from "./IoTDevice";


export class SocketDevice implements IoTDevice{
    name: string;
    status: boolean;
    mac_address: string;
    turned_on: boolean;
    group: string;
    parent: IoTDevice;

    constructor(name: string, status: boolean, mac: string, turned_on: boolean,
        group: string, parent: IoTDevice) {

        this.name = name;
        this.status = status;
        this.mac_address = mac;
        this.turned_on = turned_on;
        if (!status) {
            this.turned_on = false;
        }
        
        this.group = group;
        this.parent = parent;
        
    }
    
}