using Application.Commands.AddUser;
using Bogus;
using Bogus.DataSets;
using Domain.Entities;

namespace Application.Tests.Fixtures
{
    [CollectionDefinition(nameof(UserBogusCollection))]
    public class UserBogusCollection : ICollectionFixture<UserTestsBogusFixture>
    { }

    public class UserTestsBogusFixture : IDisposable
    {
        public User GenerateUserValid()
        {
            return GenerateListUserValid(1).First();
        }

        public List<User> GenerateListUserValid(int count)
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var user = new Faker<User>("pt_BR")
                .CustomInstantiator(f =>
                    new User(f.UniqueIndex,
                    f.Name.FullName(),
                    f.Random.Replace("######"),
                    DateTime.Now.AddMinutes(-30),
                    true));

            return user.Generate(count);
        }

        public User GenerateUserInValid()
        {
            return new User(1, "", "", DateTime.Now, true);
        }

        public AddUserCommand GenerateAddUserCommandValid()
        {
            var user = GenerateUserValid();
            return new AddUserCommand(user.Name, user.TelegramId, user.ReceiveOnlyImportant);
        }

        public AddUserCommand GenerateAddUserCommandInValid()
        {
            var user = GenerateUserInValid();
            return new AddUserCommand(user.Name, user.TelegramId, user.ReceiveOnlyImportant);
        }

        public void Dispose()
        {
        }
    }
}