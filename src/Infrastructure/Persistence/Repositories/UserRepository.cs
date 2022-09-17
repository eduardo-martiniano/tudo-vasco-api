using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await SaveChanges();
        }

        public async Task<User> GetUserByTelegramId(string telegramId)
        {
            return await _context.Users.Where(u => u.TelegramId == telegramId).FirstOrDefaultAsync();
        }

        public async Task<List<User>> ListUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
