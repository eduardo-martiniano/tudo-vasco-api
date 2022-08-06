namespace tudo_vasco_api.Models
{
    public class News
    {
        public string Title { get; set; }
        public string LearnMoreUrl { get; set; }
        public bool ImportantNews { get; set; }
        public DateTime Date { get; set; }

        private readonly string BASE_URL = "https://www.netvasco.com.br";

        public News(string content)
        {
            ImportantNews = content.Contains("</b>");
            Title = FormatTiTle(content);
            LearnMoreUrl = FormatLearnMoreUrl(content);
            Date = FormateDate(content);
        }

        private DateTime FormateDate(string content)
        {
            var stringHour = FormatHour(content);
            var currentDate = DateTime.Now;
            var year = currentDate.Year;
            var month = currentDate.Month;
            var day = currentDate.Day;
            var hour = int.Parse(stringHour.Split(':')[0]);
            var minute = int.Parse(stringHour.Split(':')[1]);

            return new DateTime(year, month, day, hour, minute, 0);
        }

        private string FormatHour(string content)
        {
            return content.Replace(" ", "")
                          .Split("<spanclass=\"noticia-hora\">")[1]
                          .Split("<")[0];
        }

        private string FormatTiTle(string content)
        {
            return content.Split("</span>")[1]
                          .Split(";")[1]
                          .Replace("</a></li>", "")
                          .Replace("'", "")
                          .Replace("<b>", "")
                          .Replace("</b>", "");
        }

        private string FormatLearnMoreUrl(string content)
        {
            var url = $"{BASE_URL}/n/{content.Split("n/")[1].Split(">")[0].Replace("</a></li>", "")}";
            return url;
        }
    }
}
