using System.Collections.Generic;

namespace DVA.Models
{
    public class NewsProviderResponse
    {
        public int TotalArticles { get; set; }
        public List<NewsArticle> NewsArticles { get; set;} = new List<NewsArticle>();
    }
}
