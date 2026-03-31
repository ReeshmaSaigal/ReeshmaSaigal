
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Linq;

namespace Domain.Service.Chat.MessageGroupServices
{
    public class MessageGroupRepository : IMessageGroupRepository
    {
        private DbHireMeNowWebApiContext DbContext;
        public MessageGroupRepository(DbHireMeNowWebApiContext _context)
        {
            DbContext = _context;
        }
        public async Task<MessageGroup> AddAsync(MessageGroup messageGroup)
        {
            DbContext.MessageGroups.Add(messageGroup);
          await DbContext.SaveChangesAsync();
            return messageGroup;
        }

        public async Task CreateChatGroupAsync( Message message)
        {
            string privateGroupName = GetPrivateGroupName(message.From, message.To);
            MessageGroup group = new MessageGroup();
            group.Name = privateGroupName;
            group.Messages.Add(message);
            group.newCount++;

            GroupMember groupMember = new GroupMember();
            groupMember.Name=message.From;
            groupMember.Email=message.From;
            groupMember.ToUserId=message.FromUserId;

            GroupMember groupMember2 = new GroupMember();
            groupMember2.Name=message.To;
            groupMember2.Email=message.To;
            groupMember2.ToUserId=message.ToUserId;

            group.GroupMembers.Add(groupMember);
            group.GroupMembers.Add(groupMember2);

            group.Messages.Add(message);
            //User userFrom = new User();
            //userFrom.Email=message.From;
            //userFrom = _userRepository.GetUserByEmail(message.From);

            //User userTo = new User();
            //userTo.Email=message.To;
            //userTo= _userRepository.GetUserByEmail(message.To);

            //group.Users.Add(userFrom);
            //group.Users.Add(userTo);

            //messageGroups.Add(group);

            //if (messagesDic.ContainsKey(groupName))
            //{
            //    return false;

            //}
            //messagesDic.Add(groupName, new List<Message>() { message });
            var grp = DbContext.MessageGroups.Where(e => e.Name==privateGroupName).Count();
            if (grp == 0) {
                //if (DbContext.MessageGroups.Where(g => g.GroupMembers.Contains(groupMember)).Count()>0)
                //{
                    await DbContext.MessageGroups.AddAsync(group);
                    DbContext.SaveChanges();
                //}
               
            }
           
            
        }

        public async Task<IList<AuthUser>> GetAllUsers()
        {
           return await DbContext.AuthUsers.ToListAsync();
        }

        public async Task<IList<MessageGroup>> GetMessageGroupByUser(Guid userId)
        {
           var res=await DbContext.MessageGroups.Include(e=>e.GroupMembers).Where(e => e.GroupMembers.Any(g=>g.ToUserId==userId)).ToListAsync();
            return res;
        }

        private string GetPrivateGroupName(string from, string to)
        {
            var stringToCompare = string.CompareOrdinal(from, to)<0;
            return stringToCompare ? $"{from}-{to}" : $"{to}-{from}";

        }
    }
}
