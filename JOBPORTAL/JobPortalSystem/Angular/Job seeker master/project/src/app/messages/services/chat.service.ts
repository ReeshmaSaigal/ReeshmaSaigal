
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { environment } from 'src/environments/environments';
import { UserModel } from '../models/userModel';
import { MessageGroup } from '../models/MessageGroup';
import { Message } from '../models/message';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  
  public myName: string = "";
  public UserId:string="";
  private chatConnection?: HubConnection;
  onlineusers: UserModel[] = [];
  public activeGroups:MessageGroup[]=[];
  messages: Message[] = [];
  privateMessages:Message[]=[];
  public privateMessageInitiated=false;
  recpID:any;
  constructor(private httpClient: HttpClient) { }
  senderId=sessionStorage.getItem('jobSeekerId');
  email=sessionStorage.getItem('email');
  registerUser(user: User) {
    console.log(user);
    const data = {email: user.name, password:"string" };
  return this.httpClient.post(environment.baseurl+'api/v1/job-seeker/login',data, { responseType: 'text' });
  }
  getAllUsers() {
 return this.httpClient.get(environment.baseurl+'api/Chat/all-users', { responseType: 'text' });
  }

  createChatConnection() {
    console.log("Creating chat connection..");
    console.log(environment.baseurl);
    
    this.chatConnection = new HubConnectionBuilder()
      .withUrl(environment.baseurl+'hubs/chat').withAutomaticReconnect().build();
      console.log("chatConnection created");
    this.chatConnection.start().catch(error => {
      console.log("chatConnection start error occuredin createChatConnection");
      
      console.log(error);

    });
    this.chatConnection.on('userConnected', () => {
      console.log("user connected");
      this.addUserConnectionId()
this.getAllUsers().subscribe({
  next: () => {
    console.log("open chat");
   

  },
  error: error => {
    console.log(error);
    
  }
});
    });

    this.chatConnection.on('OnlineUsers', (OnlineUsers:UserModel[]) => {
      console.log("OnlineUsers started");
      this.onlineusers = [...OnlineUsers];
      console.log(JSON.stringify(OnlineUsers));
    });

    this.chatConnection.on('ActiveGroups', (ActiveGroups:MessageGroup[]) => {
      console.log("ActiveGroups started");
      this.activeGroups = [...ActiveGroups];
      console.log("active groups are:");
      
      console.log(JSON.stringify(ActiveGroups));
    });

    this.chatConnection.on('NewMessage', (message:Message) => {
      console.log("OnlineUsers NewMessage");
      alert("newMessageNotified");
      this.messages = [...this.messages,message];
    });

    this.chatConnection.on('OpenPrivateChat', (message:Message) => {
      console.log("OpenPrivateChat NewMessage");
      this.privateMessages = [...this.privateMessages,message];
      console.log("OpenPrivateChat \n "+JSON.stringify(message));
      
    });
    this.chatConnection.on('NewPrivateMessage', (message:Message) => {
      console.log("NewPrivateMessage NewMessage");
      this.privateMessages = [...this.privateMessages,message];
      console.log("NewPrivateMessage \n "+JSON.stringify(message));
    });
}

  stopChatConnection() {
    this.chatConnection?.stop().catch(err => {
      console.log(err);

    })
  }
  
  setId(id?:any){
    alert(id);
 this.recpID=id;
  }

  async addUserConnectionId() {
    alert("addUserConnectionId : "+this.email);
    return await  this.chatConnection?.invoke('AddUserConnectionId', this.email)
      .catch(error =>{
console.log("error occured in AddUserConnectionId");

       console.log(error)});

  }

  sendMessage(content: string,toUser:string="",toGroup:string="") {
  
    const message: Message = {
      from: this.email,
      to: toUser,
      content:content,
      FromUserId:this.senderId,
      ToUserId: this.recpID
    };
    //change the hardcoded guid 

    console.log("Message : "+JSON.stringify(message));
 // test code 2/12/2024
 //call POST : api/chat/message 
  this.httpClient.post(environment.baseurl+'api/chat/message',message, { responseType: 'text' });

  alert("Api Called....")
 //after the completion invoke notifyNewMessageAsync event
 return this.chatConnection?.invoke("notifyNewMessageAsync", message)












    if(toGroup!=="")
    {
      alert("Group Message");
      message.toGroup=toGroup;
      return this.chatConnection?.invoke("ReceivePrivateMessage", message)
      .catch(error => console.log(error));
    }
    if(toUser!==""){
      alert("Touser private message started")
      if(!this.privateMessageInitiated){
        return this.chatConnection?.invoke("CreatePrivateChat", message)
      .catch(error => console.log(error));
      }else{
        return this.chatConnection?.invoke("ReceivePrivateMessage", message)
        .catch(error => console.log(error));
      }
    }else{
      return this.chatConnection?.invoke("ReceiveMessage", message)
      .catch(error => console.log(error));

    }
  }

  createPrivateChatGroup(toUser:String,id:string){
    const groupMembers=[{
    name: toUser,
    toUserId: id,
    email: toUser
    } ,
    {
      name: this.email,
      toUserId: this.senderId,
      email: "yadhu.aitrich@gmail.com"
      }]
    const data = {name: "newGroup", groupMembers:groupMembers };
    return this.httpClient.post(environment.baseurl+'api/chat/group',data, { responseType: 'text' });
  }
  getChatGroup(){
  return this.httpClient.get<MessageGroup[]>(environment.baseurl+'api/Chat/user/'+this.senderId+'/chatgroup');
  }
}



