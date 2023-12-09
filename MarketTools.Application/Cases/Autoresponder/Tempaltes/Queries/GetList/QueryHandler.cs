﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Models;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Queries.GetList
{
    public class QueryHandler
        (IMapper _mapper,
        IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<GetTemplatesListQuery, IEnumerable<TemplateVm>>
    {
        public async Task<IEnumerable<TemplateVm>> Handle(GetTemplatesListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AutoresponderTemplate> entities = await _authUnitOfWork
                .AutoresponderTemplates
                .GetRangeAsync();

            return _mapper.Map<IEnumerable<TemplateVm>>(entities);
        }
    }
}