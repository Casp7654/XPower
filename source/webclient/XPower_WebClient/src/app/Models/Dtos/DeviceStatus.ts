import { DeviceStatusEnum } from "./DeviceStatusEnum";
import { DeviceType } from "./DeviceType";

export interface DeviceStatus {
    ClientId: string;
    TypeId: DeviceType;
    MacAddress: string;
    StatusId: DeviceStatusEnum;
}