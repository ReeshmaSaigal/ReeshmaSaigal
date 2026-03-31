import { Component, ElementRef, ViewChild } from '@angular/core';
import { JobService } from 'src/app/jobs/services/job.service';
import { ChatService } from '../../services/chat.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../../models/user';
import { UserModel } from '../../models/userModel';
import { MessageGroup } from '../../models/MessageGroup';
@Component({
  selector: 'app-chat-message',
  templateUrl: './chat-message.component.html',
  styleUrls: ['./chat-message.component.css']
})
export class ChatMessageComponent {

  @ViewChild('messageInput')
  messageInput!: ElementRef;
  messageText: string = '';
 allUsersList: any[] = [];
 companyName:String | undefined;
 chatId!: string;
 show:boolean=false;
 inputValue: string = '';
 message:string | undefined;
 messages:any[]=[];
 email!: any;
 id:any;
 formData = {
  message: ''
};
messageGroup:MessageGroup[]=[]
submitted = false;
openchat = false;
toUser="All";
isGroupMessage=false;
groupName="";
  constructor(private jobService:JobService,public chat:ChatService,private fb: FormBuilder){
    
  }
  
  ngOnInit(){
    // this.getMessage();
    this.allUsersList=this.chat.onlineusers;
   console.log(this.allUsersList);
   this.getGroupChat();
   this.email=sessionStorage.getItem('email');
   alert(this.email);
   this.chat.myName=this.email;
  }

    openPrivateChat(touser:string){
    alert("openprivatechat");
   
this.chat.createPrivateChatGroup(touser,this.id).subscribe({
  next: () => {
   alert("createPrivate chat")

  },
  error: error => {
    console.log(error);
    // this.connectionError = error.error;
  }
});
  }

  showMessage(user:UserModel){
    this.show=true;
    this.email=user.email;
    this.id=user.id;
    console.log(this.id);
    this.openPrivateChat(user.email);
  }
  senMessage(id:any,email:any){
    console.log(this.formData);
    alert(id+email)
    this.chat.setId(id);
    if (this.formData.message.trim() !== "") {
      
      if(email!== "All"){
        if(this.isGroupMessage){
          this.chat.sendMessage(this.formData.message,email,this.groupName);
        }else{
        this.chat.sendMessage(this.formData.message,email);
        }

      }else{
     this.chat.sendMessage(this.formData.message);
      }
    }
  }

  openPrivateChatGroup(togroup:string){
    this.isGroupMessage=true;
    this.groupName=togroup;
    this.toUser=togroup;
      }
      getGroupChat(){
          this.chat.getChatGroup().subscribe((response)=>{
            console.log("-----Group chat----"+response);
            this.messageGroup=response;
          },
          (error)=>{
            alert("group chat is not active");
          })
      }
}
