using FluentValidation;

namespace Application.Commands.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be null or empty")
                .NotNull().WithMessage("Name cannot be null or empty");

            RuleFor(c => c.TelegramId)
                .NotEmpty().WithMessage("TelegramId cannot be null or empty")
                .NotNull().WithMessage("TelegramId cannot be null or empty");
        }
    }
}
