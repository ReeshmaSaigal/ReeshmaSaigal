using Domain.Service.Chat.MessageGroupServices;
using Domain.Service.Chat;
using Microsoft.AspNetCore.SignalR;
using Domain.Service.Authuser.Interfaces;
using Domain.Models;
using AutoMapper;
using HireMeNow_WebApi.API.Chat.RequestObjects;

namespace HireMeNow_WebApi.HubConfig
{
    public class ChatHub : Hub
    {
        IChatRepository _chatRepository;
        IAuthUserRepository _authUserRepository;
        IMessageGroupRepository _messageGroupRepository;
        IMapper _mapper;
       
        public ChatHub(IChatRepository chatRepository, IMessageGroupRepository messageGroupRepository, IAuthUserRepository authUserRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _messageGroupRepository=messageGroupRepository;
            _authUserRepository=authUserRepository;
            _mapper=mapper;
        }
        public override async Task OnConnectedAsync()
        {
            //string username = Context.GetHttpContext().Request.Query["username"];
            await Groups.AddToGroupAsync(Context.ConnectionId, "Come2Chat");
            await Clients.Caller.SendAsync("UserConnected");

        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Come2Chat");
            _authUserRepository.DisconnectUserByConnectionId(Context.ConnectionId);
            //if (user!=null)
            //{
            //    _unitOfWork.UserRepository.DisconnectUserAsync(user.Id);
            //    _=_unitOfWork.Complete();
            //}
            ////_chatService.RemoveUserFromList(user);
            await DisplayOnlineUsers();
            await base.OnDisconnectedAsync(exception);
        }
        public async Task AddUserConnectionId(string email)
        {
            _authUserRepository.AddUserConnectionIdAsync(email, Context.ConnectionId);
            //await DisplayMyGroups();
            await DisplayOnlineUsers();
        }
        private async Task DisplayOnlineUsers()
        {
            var OnlineUsers = await _messageGroupRepository.GetAllUsers();
            var onlineusersarray = OnlineUsers.Select(obj => obj.Email).ToArray();
            var activeUsers=_mapper.Map<IList<ChatUserDto>>(OnlineUsers);
            await Clients.Groups("Come2Chat").SendAsync("OnlineUsers", activeUsers);
        }
        private async Task DisplayMyGroups(string grpName = "")
        {
            var user = _authUserRepository.GetUserByConnectionId(Context.ConnectionId);
            if (user!=null)
            {
                IList<MessageGroup> ActiveGroups = await _messageGroupRepository.GetMessageGroupByUser(user.Id);
                //var onlineusersarray = OnlineUsers.Select(obj => obj.Email).ToArray();
                //await Clients.Groups("Come2Chat").SendAsync("ActiveGroups", ActiveGroups);
                // await Clients.Groups("Come2Chat").SendAsync("ActiveGroups", ActiveGroups);
                await Clients.Client(Context.ConnectionId).SendAsync("ActiveGroups", ActiveGroups);
                if (grpName!="")
                {
                    await Clients.Group(grpName).SendAsync("ActiveGroups", ActiveGroups);
                }
            }
        }
        private async Task DisplayGroups(Guid userId)
        {
            var OnlineUsers = await _messageGroupRepository.GetMessageGroupByUser(userId);
            //var onlineusersarray = OnlineUsers.Select(obj => obj.Email).ToArray();
            await Clients.Groups("Come2Chat").SendAsync("OnlineUsers", OnlineUsers);
        }
        private async Task RefreshMyGroups()
        {
            var user = _authUserRepository.GetUserByConnectionId(Context.ConnectionId);
            if (user!=null)
            {
               IList<MessageGroup> ActiveGroups = await _messageGroupRepository.GetMessageGroupByUser(user.Id);
                //var onlineusersarray = OnlineUsers.Select(obj => obj.Email).ToArray();
                await Clients.Groups("Come2Chat").SendAsync("ActiveGroups", ActiveGroups);
            }
        }

        public async Task ReceiveMessage(Message message)
        {
            await Clients.Group("Come2Chat").SendAsync("NewMessage", message);
        }

        public async Task CreatePrivateChat(Message message)
        {
            AuthUser fromUser=await _authUserRepository.GetAuthUserByUserEmail(message.From);
            message.FromUserId = fromUser.Id;

            AuthUser toUser = await _authUserRepository.GetAuthUserByUserEmail(message.To);
            message.ToUserId = toUser.Id;

            string privateGroupName = GetPrivateGroupName(message.From, message.To);
            await _messageGroupRepository.CreateChatGroupAsync( message);
            message.ToGroup=privateGroupName;
            await Groups.AddToGroupAsync(Context.ConnectionId, privateGroupName);
            var authUser = await _authUserRepository.GetAuthUserByUserEmail(message.To);
            if (authUser!=null&&authUser.ConnectionId !=null)
            {
                await Groups.AddToGroupAsync(authUser.ConnectionId, privateGroupName);
                await Clients.Client(authUser.ConnectionId).SendAsync("OpenPrivateChat", message);
            }
            await DisplayMyGroups(privateGroupName);
        }
        public async Task ReceivePrivateMessage(Message message)
        {
            if (message.ToGroup!=null)
            {
                _chatRepository.AddMessageAsync(message);
                await Clients.Group(message.ToGroup).SendAsync("NewPrivateMessage", message);
            }
            else
            {
                string privateGroupName = GetPrivateGroupName(message.From, message.To);
                _chatRepository.AddMessageAsync(message);
                await Clients.Group(privateGroupName).SendAsync("NewPrivateMessage", message);
            }
        }
        public async Task RemovePrivateChat(string from, string to)
        {
            string privateGroupName = GetPrivateGroupName(from, to);
            await Clients.Group(privateGroupName).SendAsync("ClosePrivateChat");
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, privateGroupName);

        }
        //private string GetPrivateGroupName(string from, string to)
        //{
        //    var stringToCompare = string.CompareOrdinal(from, to)<0;
        //    return stringToCompare ? $"{from}-{to}" : $"{to}-{from}";

        //}



        public async Task GetMyPrivateGroups(String email)
        {

            //await Clients.Group("Come2Chat").SendAsync("NewMessage", message);
        }
        private string GetPrivateGroupName(string from, string to)
        {
            var stringToCompare = string.CompareOrdinal(from, to)<0;
            return stringToCompare ? $"{from}-{to}" : $"{to}-{from}";

        }

        public async Task notifyNewMessageAsync(Message message)
        {
            AuthUser touser = await _authUserRepository.GetAuthUserByUserId(message.ToUserId.Value);
            await Clients.Client(touser.ConnectionId).SendAsync("NewMessage", message);

            //await Clients.Group("Come2Chat").SendAsync("NewMessage", message);
        }
    }
}
