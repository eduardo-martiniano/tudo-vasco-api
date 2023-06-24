namespace Core.Exceptions
{
    public class DomainException : Exception
    {
        public List<string> Errors { get; private set; } = new List<string>();

        public DomainException(List<string> errors)
        {
            Errors = errors;
        }

        public DomainException() { }

        public DomainException(string message) : base(message) { }
    }
}
