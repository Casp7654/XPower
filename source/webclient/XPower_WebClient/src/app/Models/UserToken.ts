import { User } from "./User";

export class UserToken extends User{
    constructor(username : string, password : string, email : string, firstname : string, lastname: string, _token : string){
        super(username, password, email, firstname, lastname)
        this.token = _token;
    }
    token! : string
}