namespace Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task<bool> Commit();
    }
}
