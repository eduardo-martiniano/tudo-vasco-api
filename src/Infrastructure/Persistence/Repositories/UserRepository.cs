using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> Commit()
        {
            return await _context.Commit();
        }

        public void Dispose()
        {

        }

        public async Task<User> FindByTelegramIdAsync(string telegramId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.TelegramId == telegramId);
        }
    }
}
