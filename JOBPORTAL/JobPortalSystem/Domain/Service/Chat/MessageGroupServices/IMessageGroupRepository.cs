

using Domain.Models;

namespace Domain.Service.Chat.MessageGroupServices
{
    public interface IMessageGroupRepository
    {
        Task<MessageGroup> AddAsync(MessageGroup messageGroup);
        Task CreateChatGroupAsync( Message message);
        Task<IList<AuthUser>> GetAllUsers();
        Task<IList<MessageGroup>> GetMessageGroupByUser(Guid userId);
    }
}
