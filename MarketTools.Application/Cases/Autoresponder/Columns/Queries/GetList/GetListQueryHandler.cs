using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Columns.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Columns.Queries.GetList
{
    public class GetListQueryHandler
        (IMapper _mapper,
        IAuthReadHelper _authReadHelper,
        IMainDatabaseContext _context)
        : IRequestHandler<GetListColumnsQuery, IEnumerable<ColumnVm>>
    {
        public async Task<IEnumerable<ColumnVm>> Handle(GetListColumnsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AutoresponderColumn> entities = await _context.AutoresponderColumns
                .Where(x => x.UserId == _authReadHelper.UserId)
                .ToListAsync();

            IEnumerable<ColumnVm> result = _mapper.Map<IEnumerable<ColumnVm>>(entities);

            return result;
        }
    }
}
