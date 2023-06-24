using Application.Commands.AddUser;
using Application.Tests.Fixtures;
using Core.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using Moq.AutoMock;

namespace Application.Tests.CommandHandlers
{
    [Collection(nameof(UserBogusCollection))]
    public class AddUserCommandHandlerTests
    {
        private readonly UserTestsBogusFixture _userTestsBogusFixture;
        private readonly AutoMocker _mocker;

        public AddUserCommandHandlerTests(UserTestsBogusFixture userTestsBogusFixture)
        {
            _userTestsBogusFixture = userTestsBogusFixture;
            _mocker = new AutoMocker();
        }

        [Fact(DisplayName = "Adicionar novo usuario invalido Handler")]
        [Trait("Categoria", "Usuario - Criação de usuario")]
        public async Task AddUserCommandHandler_CommandUserInvalid_ThrowDomainException()
        {
            //Arrange
            var userRepo = new Mock<IUserRepository>();
            var user = _userTestsBogusFixture.GenerateUserInValid();
            var addUserCommand = new AddUserCommand(user.Name, user.TelegramId, true);
            var addUserCommandHandler = new AddUserCommandHandler(userRepo.Object);

            //Act & Assert
            await Assert.ThrowsAsync<DomainException>(() => addUserCommandHandler.Handle(addUserCommand, CancellationToken.None));
        }

        [Fact(DisplayName = "Adicionar novo usuario valido")]
        [Trait("Categoria", "Usuario - Criação de usuario")]
        public async Task AddUserCommandHandler_CommandUserValid_Success()
        {
            //Arrange
            var user = _userTestsBogusFixture.GenerateUserValid();
            var addUserCommand = new AddUserCommand(user.Name, user.TelegramId, true);
            var addUserCommandHandler = _mocker.CreateInstance<AddUserCommandHandler>();

            //Act
            await addUserCommandHandler.Handle(addUserCommand, CancellationToken.None);

            //Assert
            _mocker.GetMock<IUserRepository>().Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
            _mocker.GetMock<IUserRepository>().Verify(r => r.Commit(), Times.Once);
        }
    }
}
