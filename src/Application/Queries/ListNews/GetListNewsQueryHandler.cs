using Application.Queries.ListUsers;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ListNews
{
    public class GetListNewsQueryHandler : IRequestHandler<GetListNewsQuery, List<NewsDto>>
    {
        private readonly INewsService _newsService;
        public GetListNewsQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<List<NewsDto>> Handle(GetListNewsQuery request, CancellationToken cancellationToken)
        {
            var users = (await _newsService.GetNews(onlyImportant: false)).Select(u => new NewsDto(u)).ToList();

            return await Task.FromResult(users);
        }
    }
}
