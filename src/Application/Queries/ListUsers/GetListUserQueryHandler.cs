using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ListUsers
{
    public class GetListUserQueryHandler : IRequestHandler<GetListUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetListUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetListUsersQuery query, CancellationToken cancellationToken)
        {
            //var users = (await _userRepository.ListUsers()).Select(u => new UserDto(u)).ToList();

            //return await Task.FromResult(users);

            return null;
        }
    }
}
