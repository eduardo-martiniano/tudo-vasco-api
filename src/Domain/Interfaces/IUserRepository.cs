using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task SaveChanges();
        Task<List<User>> ListUsers();
        Task<User> GetUserByTelegramId(string telegramId);
    }
}
