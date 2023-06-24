using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ListNews
{
    public class NewsDto
    {
        public string Title { get; set; }
        public string LearnMoreUrl { get; set; }
        public bool ImportantNews { get; set; }
        public DateTime Date { get; set; }

        public NewsDto() { }

        public NewsDto(News news)
        {
            Title = news.Title;
            LearnMoreUrl = news.LearnMoreUrl;
            Date = news.Date;
            ImportantNews = news.ImportantNews;
        }
    }
}
