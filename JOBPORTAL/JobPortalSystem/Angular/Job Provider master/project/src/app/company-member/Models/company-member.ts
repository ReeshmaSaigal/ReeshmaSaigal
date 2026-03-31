export interface companyMember{
    companyId:string;
    firstname: string,
    lastname: string,
    username: string,
    email: string,
    phone: number,
    password: string
}

export interface listMember{
    id:string;
    firstName: string,
    lastName: string,
    username: string,
    email: string,
    phone: number,
    company: string,
    password: string,
    jobPosts: string[];    
}