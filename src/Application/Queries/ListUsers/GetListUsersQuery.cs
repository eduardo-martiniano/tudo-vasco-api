using MediatR;

namespace Application.Queries.ListUsers
{
    public class GetListUsersQuery : IRequest<List<UserDto>>
    {
    }
}
