using Domain.Interfaces;
using MediatR;

namespace Application.Commands.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, AddUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var errors = new AddUserCommandValidator().Validate(request).Errors;
            var userByTelegramId = await _userRepository.GetUserByTelegramId(request.TelegramId);
            
            if (userByTelegramId != null)
                errors.Add(new FluentValidation.Results.ValidationFailure("TelegramId", "There is already a user with this TelegramId"));

            if (errors.Any()) return null;

            var user = request.Map();
            await _userRepository.AddUser(user);
            var response = new AddUserResponse(user);

            return response;
        }
    }
}
