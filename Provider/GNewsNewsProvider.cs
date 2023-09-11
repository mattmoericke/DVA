using DVA.Models;
using System.Security.Policy;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;

namespace DVA.Provider
{
    public class GNewsNewsProvider : NewsProviderBase, INewsProvider
    {
        private static string API_KEY = "ea7df284fbcdd24df652231d2857a74a";

        public async Task<NewsProviderResponse> TopHeadlinesAsync(string category)
        {
            string queryString = $"top-headlines?category={category.ToLower()}";

            NewsProviderResponse retVal = await QueryGNews(queryString);

            return retVal;
        }

        public async Task<NewsProviderResponse> SearchAsync(string searchPhrase)
        {
            string queryString = $"search?q={searchPhrase}";

            NewsProviderResponse retVal = await QueryGNews(queryString);

            return retVal;
        }

        private async Task<NewsProviderResponse> QueryGNews(string queryString)
        {
            string url = $"https://gnews.io/api/v4/{queryString}&lang=en&country=us&max=10&apikey={API_KEY}";
            NewsProviderResponse retVal = new NewsProviderResponse();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
            List<Article> articles = data.articles;

            for (int i = 0; i < articles.Count; i++)
            {
                NewsArticle newsArticle = new NewsArticle();
                newsArticle.Title = articles[i].title;
                newsArticle.Content = articles[i].content;
                newsArticle.Url = articles[i].url;
                newsArticle.Description = articles[i].description;
                newsArticle.Image = articles[i].image;
                retVal.NewsArticles.Add(newsArticle);
            }

            retVal.TotalArticles = data.totalArticles;

            return retVal;
        }


        public class ApiResponse
        {
            public int totalArticles { get; set; }
            public List<Article> articles { get; set; } = new List<Article>();
        }

        public class Article
        {
            public string title { get; set; } = "";
            public string description { get; set; } = "";
            public string content { get; set; } = "";
            public string url { get; set; } = "";
            public string image { get; set; } = "";
            public Source source { get; set; } = new Source();
        }

        public class Source
        {
            public string name { get; set; } = "";
            public string url { get; set; } = "";
        }
    }



}
