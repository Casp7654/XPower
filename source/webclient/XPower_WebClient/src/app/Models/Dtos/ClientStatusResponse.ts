import { ClientStatusEnum } from "./ClientStatusEnum";

export interface ClientStatusResponse {
    ClientId: string;
    StatusId: ClientStatusEnum;
}