using Application.Commands.AddUser;
using Application.Tests.Fixtures;
using Domain.Interfaces;
using Moq;

namespace Application.Tests.Commands
{
    [Collection(nameof(UserBogusCollection))]
    public class AddUserCommandTests
    {
        private readonly UserTestsBogusFixture _userTestsBogusFixture;
        
        public AddUserCommandTests(UserTestsBogusFixture userTestsBogusFixture)
        {
            _userTestsBogusFixture = userTestsBogusFixture;
        }

        [Fact(DisplayName = "Adicionar novo usuario invalido")]
        [Trait("Categoria", "Usuario - Criação de usuario")]
        public void AddUserCommand_CommandUserInvalid_MustReturnInvalidUser()
        {
            // Arrange
            var addUserCommand = _userTestsBogusFixture.GenerateAddUserCommandInValid();
            var userRepo = new Mock<IUserRepository>();

            // Act
            var result = addUserCommand.Validate(userRepo.Object);
            
            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(AddUserCommandValidator.TELEGRAM_ID_INVALID, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AddUserCommandValidator.USER_NAME_INVALID, result.Errors.Select(c => c.ErrorMessage));
        }

        [Fact(DisplayName = "Adicionar novo usuario invalido (TelegramId já em uso)")]
        [Trait("Categoria", "Usuario - Criação de usuario")]
        public void AddUserCommand_CommandUserTelegramIdAlreadyInUse_MustReturnInvalidUser()
        {
            // Arrange
            var addUserCommand = _userTestsBogusFixture.GenerateAddUserCommandValid();
            var userRepo = new Mock<IUserRepository>();
            
            userRepo.Setup(r => r.FindByTelegramIdAsync(addUserCommand.TelegramId))
                .Returns(Task.FromResult(addUserCommand.MapToEntity()));

            // Act
            var result = addUserCommand.Validate(userRepo.Object);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(AddUserCommandValidator.TELEGRAM_ID_ALREADY_IN_USE, result.Errors.Select(c => c.ErrorMessage));
        }

        [Fact(DisplayName = "Adicionar novo usuario invalido")]
        [Trait("Categoria", "Usuario - Criação de usuario")]
        public void AddUserCommand_CommandUserValid_MustReturnValidUser()
        {
            // Arrange
            var addUserCommand = _userTestsBogusFixture.GenerateAddUserCommandValid();
            var userRepo = new Mock<IUserRepository>();

            // Act
            var result = addUserCommand.Validate(userRepo.Object);

            // Assert
            Assert.True(result.IsValid);
        }

    }
}