import { SocketDeviceRequestConverter } from "../SocketDeviceRequestConverter";

export class SocketDeviceJsonRequestConverter implements SocketDeviceRequestConverter {
    
    // Returns json message for socket device turn on action.
    TurnOn(): string {
        return JSON.stringify({cmd: "on"});
    }

    // Returns json message for socket device turn off action.
    TurnOff(): string {
        return JSON.stringify({cmd: "off"});
    }
}