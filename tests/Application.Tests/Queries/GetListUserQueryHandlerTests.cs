using Application.Commands.AddUser;
using Application.Queries.ListNews;
using Application.Queries.ListUsers;
using Application.Tests.Fixtures;
using Domain.Interfaces;
using Moq;
using Moq.AutoMock;

namespace Application.Tests.Queries
{
    [Collection(nameof(UserBogusCollection))]
    public class GetListUserQueryHandlerTests
    {
        private readonly UserTestsBogusFixture _userTestsBogusFixture;
        private readonly AutoMocker _mocker;

        public GetListUserQueryHandlerTests(UserTestsBogusFixture userTestsBogusFixture)
        {
            _userTestsBogusFixture = userTestsBogusFixture;
            _mocker = new AutoMocker();
        }

        [Fact(DisplayName = "Listar usuarios cadastrados")]
        [Trait("Categoria", "Usuario - Listagem de usuarios")]
        public async Task GetListUserQueryHandler_Handle_ListAllUsers()
        {
            // Arrange 
            var userRepo = _mocker.GetMock<IUserRepository>();
            userRepo.Setup(u => u.FindAllAsync())
                .Returns(Task.FromResult(_userTestsBogusFixture.GenerateListUserValid(50)));
            
            var getListUserQueryHandler = _mocker.CreateInstance<GetListUserQueryHandler>();
            var query = new GetListUsersQuery();

            // Act
            var result = await getListUserQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.Any());
        }
    }
}
