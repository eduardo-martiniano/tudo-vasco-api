using Domain.Interfaces;
using FluentValidation;

namespace Application.Commands.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(USER_NAME_INVALID)
                .NotNull().WithMessage(USER_NAME_INVALID);

            RuleFor(c => c.TelegramId)
                .NotEmpty().WithMessage(TELEGRAM_ID_INVALID)
                .NotNull().WithMessage(TELEGRAM_ID_INVALID)
                .Must(IsUniqueTelegramId).WithMessage(TELEGRAM_ID_ALREADY_IN_USE);

        }

        private bool IsUniqueTelegramId(string telegramId)
        {
            return _userRepository.FindByTelegramIdAsync(telegramId).Result == null;
        }
        
        public static string TELEGRAM_ID_INVALID = "TelegramId não pode ser nulo ou vazio";
        public static string TELEGRAM_ID_ALREADY_IN_USE = "TelegramId já está sendo usado";
        public static string USER_NAME_INVALID = "O nome do usuario não pode ser nulo ou vazio";

    }
}
