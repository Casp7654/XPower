import { DeviceStatus } from "./DeviceStatus";

export interface DeviceStatusResponse<T> {
    device: DeviceStatus;
    data: T;
}