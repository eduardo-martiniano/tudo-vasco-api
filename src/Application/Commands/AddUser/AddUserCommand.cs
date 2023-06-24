using Domain.Entities;
using Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Application.Commands.AddUser
{
    public class AddUserCommand : IRequest<AddUserResponse>
    {
        public string Name { get; set; }
        public string TelegramId { get; set; }
        public bool ReceiveOnlyImportant { get; set; }

        public AddUserCommand(string name, string telegramId, bool receiveOnlyImportant)
        {
            Name = name;
            TelegramId = telegramId;
            ReceiveOnlyImportant = receiveOnlyImportant;
        }

        public AddUserCommand() { }

        public ValidationResult Validate(IUserRepository userRepository)
        {
            return new AddUserCommandValidator(userRepository).Validate(this);
        }

        public User MapToEntity()
        {
            return new User(0, Name, TelegramId, null, ReceiveOnlyImportant);
        }
    }
}
