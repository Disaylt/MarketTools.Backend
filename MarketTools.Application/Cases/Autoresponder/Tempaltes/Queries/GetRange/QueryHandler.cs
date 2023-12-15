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
        : IRequestHandler<GetRangeQuery, IEnumerable<TemplateVm>>
    {
        private readonly IAuthRepository<AutoresponderTemplate> _repository = _authUnitOfWork.AutoresponderTemplates;
        public async Task<IEnumerable<TemplateVm>> Handle(GetRangeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AutoresponderTemplate> entities = await _repository.GetRangeAsync();

            return _mapper.Map<IEnumerable<TemplateVm>>(entities);
        }
    }
}
