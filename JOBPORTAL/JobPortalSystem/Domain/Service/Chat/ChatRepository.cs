
using Domain.Models;
using Domain.Service.Chat.MessageGroupServices;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.Chat
{
    public class ChatRepository: IChatRepository
    {
        private DbHireMeNowWebApiContext DbContext;
        IMessageGroupRepository _messageGroupRepository;
     
        public ChatRepository(DbHireMeNowWebApiContext _context, IMessageGroupRepository messageGroupRepository)
        {
            DbContext = _context;
            _messageGroupRepository = messageGroupRepository;
        }

        public async Task<Message> AddMessageAsync(Message message)
        {
            if (message.MessageGroupId!=null)
            {
                DbContext.Messages.Add(message);
                DbContext.SaveChanges();

            }
            else
            {
                IList<Guid> ids = new List<Guid>();
                ids.Add(message.FromUserId.Value);
                ids.Add(message.ToUserId.Value);

                var groupslist = GetMessageGroupContainsMembers(ids);
                if (groupslist!=null && groupslist.Count>0)
                {
                    message.MessageGroupId = groupslist[0].Id;
                    message.MessageGroup = groupslist[0];
                    DbContext.Messages.Add(message);
                    DbContext.SaveChanges();
                }
                else
                {
                    await _messageGroupRepository.CreateChatGroupAsync(message);
                }
            }
            return message;

        }
        public IList<MessageGroup> GetMessageGroupContainsMembers(IList<Guid> memberIds)
        {
            
            var allMessageGroups = DbContext.MessageGroups
         .Include(mg => mg.GroupMembers) // Ensure GroupMembers are included in the query
         .ToList();

            var messageGroupsWithAllMembers = allMessageGroups
                .Where(messageGroup =>
                    memberIds.All(memberId =>
                        messageGroup.GroupMembers.Any(gm => gm.ToUserId == memberId)
                    )
                )
                .ToList();

            return messageGroupsWithAllMembers;

        }


        public async Task<IList<Message>> GetMessagesByGroup(Guid groupId)
        {
           var res=await  DbContext.Messages.Where(e=>e.MessageGroupId==groupId).ToListAsync();
            return res;

        }

      
    }
}
