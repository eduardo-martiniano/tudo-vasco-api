using System.Net;
using tudo_vasco_api.Interfaces;
using tudo_vasco_api.Models;

namespace tudo_vasco_api.Services
{
    public class NewsService : INewsService
    {
        private readonly string BASE_URL = "https://www.netvasco.com.br";
        public async Task<List<News>> GetNews()
        {
            var content = string.Empty;
            using (WebClient client = new WebClient())
            {
                content = client.DownloadString(BASE_URL);
            }

            content = content.Split("<div class=\"manchetes\">")[1];

            var contentList = content.Split("\n");

            contentList = contentList.Where(c => c.Contains("</li>")).ToArray();
            var listaDeNoticias = new List<News>();


            foreach (var item in contentList)
            {
                try
                {
                    listaDeNoticias.Add(new News
                    {
                        Title = GetTiTle(item),
                        Hour = GetHour(item),
                        LearnMoreUrl = GetLearnMoreUrl(item)
                    });
                }

                catch (Exception) { }

            }

            return listaDeNoticias;
        }

        private string GetHour(string content)
        {
            return content.Replace(" ", "").Split("<spanclass=\"noticia-hora\">")[1].Split("<")[0];
        }

        private string GetTiTle(string content)
        {
            return content.Split("</span>")[1].Split(";")[1].Replace("</a></li>", "").Replace("'", "");
        }

        private string GetLearnMoreUrl(string content)
        {
            var url = $"{BASE_URL}/n/{content.Split("n/")[1].Split(">")[0].Replace("</a></li>", "")}";
            return url;
        }
    }
}
