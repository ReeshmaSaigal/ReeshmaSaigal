

using AutoMapper;
using Domain.Models;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.Chat;
using Domain.Service.Chat.MessageGroupServices;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.API.Chat.RequestObjects;
using HireMeNow_WebApi.HubConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HireMeNow_WebApi.API.Chat
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        IChatRepository chatRepository;
        IAuthUserRepository _authUserRepository;
        IMessageGroupRepository messageGroupRepository;
        IMapper mapper;
        private readonly IHubContext<ChatHub> _chatHubContext;
        public ChatController(IChatRepository _chatRepository,IMessageGroupRepository _messageGroupRepository, IMapper _mapper, IAuthUserRepository authUserRepository, IHubContext<ChatHub> chatHubContext) {
            chatRepository= _chatRepository;
            messageGroupRepository= _messageGroupRepository;    
            mapper= _mapper;
            _chatHubContext = chatHubContext;
            _authUserRepository=authUserRepository;
        }

        [HttpPost]
        [Route("group/{groupId}/message")]
        public IActionResult AddMessage(Message message,Guid groupId)
        {
            chatRepository.AddMessageAsync(message);
            return Ok();
        }

        [HttpPost]
        [Route("group")]
        public async Task<IActionResult> CreateNewChatGroupAsync(MessageGroup messagegroup)
        {
            var res=await messageGroupRepository.AddAsync(messagegroup);
            return Ok(res);
        }

        

        [HttpGet]
        [Route("group/{groupId}/messages")]
        public async Task<IActionResult> GetChatByGroupAsync(Guid groupId)
        {
            IList<Message> res = await chatRepository.GetMessagesByGroup(groupId);
            return Ok(res);
        }

        [HttpGet]
        [Route("user/{userId}/chatgroup")]
        public async Task<IActionResult> GetGroupsByUserAsync(Guid userId)
        {
            IList<MessageGroup> res = await messageGroupRepository.GetMessageGroupByUser(userId);
            return Ok(res);
        }
        [HttpGet]
        [Route("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            IList<AuthUser> res = await messageGroupRepository.GetAllUsers();
           var returnUsers= mapper.Map<IList<ChatUserDto>>(res);
            return Ok(returnUsers);
        }


        [HttpPost]
        [Route("message")]
        public async Task<IActionResult> CreateMessages(Message message)
        {
            try
            {
                message=await chatRepository.AddMessageAsync(message);
                //AuthUser touser = await _authUserRepository.GetAuthUserByUserId(message.ToUserId.Value);
                //await _chatHubContext.Clients.Client(touser.ConnectionId).InvokeAsync<string>("notifyNewMessageAsync", message, default); // Assuming string return type
            }catch(Exception ex) { }
                return Ok();
        }

    }
}
