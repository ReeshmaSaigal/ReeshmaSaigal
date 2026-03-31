export interface Message{
    from:string | null;
    to?:string;
    content:string;
    SentDate?:Date;
    toGroup?:string;
    FromUserId:any;
    ToUserId?:string;
    }