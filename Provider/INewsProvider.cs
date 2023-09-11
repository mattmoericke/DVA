using DVA.Models;
using System.Threading.Tasks;

namespace DVA.Provider
{
    public interface INewsProvider
    {
        public Task<NewsProviderResponse> SearchAsync(string searchPhrase);
        public Task<NewsProviderResponse> TopHeadlinesAsync(string category);
    }
}
