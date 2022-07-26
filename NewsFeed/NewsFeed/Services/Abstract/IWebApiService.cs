using System.Threading.Tasks;

namespace NewsFeed.Services
{
    public interface IWebApiService
    {
        Task<T> GetRequest<T>( string endPoint, string keyword = "keyword");
    }
}