using Domain.Interfaces;

namespace Domain.Entities
{
    public class User : IAggregateRoot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string TelegramId { get; private set; }
        public DateTime? DateLastNews { get; private set; }
        public bool ReceiveOnlyImportant { get; private set; }

        public User(int id, string name, string telegramId, DateTime? dateLastNews, bool receiveOnlyImportant)
        {
            Id = id;
            Name = name;
            TelegramId = telegramId;
            DateLastNews = dateLastNews;
            ReceiveOnlyImportant = receiveOnlyImportant;
        }
    }
}
