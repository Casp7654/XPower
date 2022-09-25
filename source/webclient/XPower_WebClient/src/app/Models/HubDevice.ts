import { IoTDevice } from "./IoTDevice";

export class HubDevice implements IoTDevice{
    
    name: string;
    status: boolean;
    mac_address: string;

    constructor() {
        this.name = "Hub1";
        this.status = true;
        this.mac_address = "MAC:123:123:123"
    }
    
}