using Domain.Entities;

namespace Application.Commands.AddUser
{
    public class AddUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelegramId { get; set; }
        public DateTime? DateLastNews { get; set; }
        public bool ReceiveOnlyImportant { get; set; }


        public AddUserResponse() { }

        public AddUserResponse(User user)
        {
            Id = user.Id;
            DateLastNews = user.DateLastNews;
            Name = user.Name;
            TelegramId = user.TelegramId;   
            ReceiveOnlyImportant = user.ReceiveOnlyImportant;
        }
    }
}
