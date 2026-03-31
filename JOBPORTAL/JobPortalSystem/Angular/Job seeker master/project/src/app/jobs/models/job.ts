export class job{
    id :String | undefined;
    jobTitle:string | undefined;
    jobSummary:string | undefined;
    salary:string | undefined;
    location:string | undefined;
    type:string | undefined;
    workplace:string | undefined;
    saved:boolean | undefined;
    applied:boolean | undefined;
    company:company[]=[];
}


export class response
{
    currentPage :number | undefined;
    data:job[]=[] ;
    totalItems:number | undefined;
    totalPages: number | undefined;
}
export class company{
    id:number | undefined;
    name:string | undefined;
}

