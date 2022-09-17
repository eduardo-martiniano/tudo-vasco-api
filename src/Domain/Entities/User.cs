namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelegramId { get; set; }
        public DateTime? DateLastNews { get; set; }
        public bool ReceiveOnlyImportant { get; set; }
    }
}
