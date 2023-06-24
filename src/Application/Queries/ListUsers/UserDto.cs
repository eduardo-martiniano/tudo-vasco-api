using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ListUsers
{
    public class UserDto
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string TelegramId { get; private set; }
        public DateTime? DateLastNews { get; private set; }
        public bool ReceiveOnlyImportant { get; private set; }

        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            TelegramId = user.TelegramId;
            DateLastNews = user?.DateLastNews;
            ReceiveOnlyImportant = user.ReceiveOnlyImportant;
        }
    }
}
