
using Domain.Models;

namespace Domain.Service.Chat
{
    public interface IChatRepository
    {
        Task<Message> AddMessageAsync(Message message);
        Task<IList<Message>> GetMessagesByGroup(Guid groupId);
    }
}
