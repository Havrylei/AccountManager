export interface RegistrateUser {
    login:string;
    email:string,
    password:string;
    confirm:string;
    firstName:string;
    genderID:number;
    countryID: number;
    birthDate:Date;
}