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
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelegramId { get; set; }
        public DateTime? DateLastNews { get; set; }
        public bool ReceiveOnlyImportant { get; set; }

        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            TelegramId = user.TelegramId;
            DateLastNews = user.DateLastNews;
            ReceiveOnlyImportant = user.ReceiveOnlyImportant;
        }

        public UserDto() { }
    }
}
