using Core.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            ValidateCommand(request);

            var entity = request.MapToEntity();
            await _userRepository.AddAsync(entity);
            await _userRepository.Commit();

            return new AddUserResponse(entity);
        }

        public void ValidateCommand(AddUserCommand request)
        {
            var result = request.Validate(_userRepository);
            
            if (!result.IsValid)
            {
                throw new DomainException(result.Errors.Select(e => e.ErrorMessage).Distinct().ToList());
            }
        }
    }
}
