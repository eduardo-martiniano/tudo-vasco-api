using Domain.Entities;
using MediatR;

namespace Application.Commands.AddUser
{
    public class AddUserCommand : IRequest<AddUserResponse>
    {
        public string Name { get; set; }
        public string TelegramId { get; set; }
        public bool ReceiveOnlyImportant { get; set; }

        public User Map()
        {
            return new User
            {
                Name = Name,
                TelegramId = TelegramId,
                ReceiveOnlyImportant = ReceiveOnlyImportant
            };
        }
    }
}
