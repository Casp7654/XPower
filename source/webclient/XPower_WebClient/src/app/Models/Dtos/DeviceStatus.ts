import { DeviceStatusEnum } from "./DeviceStatusEnum";
import { DeviceType } from "./DeviceType";

export interface DeviceStatus {
    clientId: string;
    typeId: DeviceType;
    macAddress: string;
    statusId: DeviceStatusEnum;
}