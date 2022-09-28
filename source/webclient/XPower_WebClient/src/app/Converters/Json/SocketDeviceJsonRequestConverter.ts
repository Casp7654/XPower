import { SocketDeviceRequestConverter } from "../SocketDeviceRequestConverter";

export class SocketDeviceJsonRequestConverter implements SocketDeviceRequestConverter {
    
    TurnOn(): string {
        return JSON.stringify({cmd: "on"});
    }

    TurnOff(): string {
        return JSON.stringify({cmd: "off"});
    }
}