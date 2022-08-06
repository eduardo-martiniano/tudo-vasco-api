using tudo_vasco_api.Models;

namespace tudo_vasco_api.Interfaces
{
    public interface INewsService
    {
        Task<List<News>> GetNews();
    }
}
