export class User {
    constructor(username : string, password : string, email : string, firstname : string, lastname: string){
        this.username = username;
        this.password = password;
        this.email = email;
        this.firstName = firstname;
        this.lastName = lastname;
    }

    username : string;
    password : string;
    email : string;
    firstName : string;
    lastName : string;
}