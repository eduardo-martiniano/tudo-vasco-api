using Application.Queries.ListUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ListNews
{
    public class GetListNewsQuery : IRequest<List<NewsDto>>
    {
    }
}
