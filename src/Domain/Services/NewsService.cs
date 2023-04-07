using Domain.Entities;
using Domain.Interfaces;
using System.Net;

namespace Domain.Services
{
    public class NewsService : INewsService
    {
        private readonly string BASE_URL = "https://www.netvasco.com.br";
        public async Task<IList<News>> GetNews(bool onlyImportant)
        {
            var content = string.Empty;
            using (WebClient client = new WebClient())
            {
                content = client.DownloadString(BASE_URL);
            }

            content = content.Split("<div class=\"manchetes\">")[1];
            content = content.Split("</ul><span id=\"data")[0];

            var contentList = content.Split("\n");

            contentList = contentList.Where(c => c.Contains("</li>")).ToArray();
            var newsList = new List<News>();

            Array.ForEach(contentList, c =>
            {
                try
                {
                    newsList.Add(new News(c));
                }

                catch (Exception) { }
            });

            if (onlyImportant)
                return newsList.Where(n => n.ImportantNews).ToList();

            return newsList;
        }

    }
}
