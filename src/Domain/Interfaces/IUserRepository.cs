using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddAsync(User user);
        Task<User> FindByTelegramIdAsync(string telegramId);
        Task<List<User>> FindAllAsync();
    }
}
