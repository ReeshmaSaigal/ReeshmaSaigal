export class Registration {
    checkbox: boolean;
    id: string;
    dateApplied: string;
    companyName : string;
    jobRole : string;
    type: string;
    position: string;
    contactPhone : string;
    contactMail : string;
    contactWhatsapp : string;
    status: string;
  
    constructor(data: any) {
      this.checkbox = false;
      this.id = data.id || 0;
      this.dateApplied = data.dateApplied;
      this.companyName = data.companyName|| '';
      this.jobRole = data.jobRole || '';
      this.type = data.type || '';
      this.position = data.position || '';
      this. contactPhone  = data.contactPhone || '';
      this. contactMail  = data.contactMail   || '';
      this. contactWhatsapp  = data.contactWhatsapp || '';
      this.status = data.status || '';
    }
  }
  