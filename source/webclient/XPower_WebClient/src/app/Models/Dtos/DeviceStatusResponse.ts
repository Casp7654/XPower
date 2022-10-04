import { DeviceStatus } from "./DeviceStatus";

export interface DeviceStatusResponse<T> {
    Device: DeviceStatus;
    Data: T;
}