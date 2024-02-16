﻿using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Response.Command
{
    public class CreateResponseCommand : IRequest<AutoresponderResultModel>
    {
        public int ConnectionId { get; set; }
        public required string Article { get; set; }
        public required string Text { get; set; }
        public int Rating { get; set; }
    }

    public class CreateCommandHandler(IAutoresponderContextLoadService _autoresponderContextService,
        IAutoresponderResponseServiceFactory _autoresponderResponseServiceFactory)
        : IRequestHandler<CreateResponseCommand, AutoresponderResultModel>
    {
        public async Task<AutoresponderResultModel> Handle(CreateResponseCommand command, CancellationToken cancellationToken)
        {
            AutoresponderRequestModel buildRequest = CreateRequest(command);
            AutoresponderContext context = await _autoresponderContextService.Create(command.ConnectionId);

            return _autoresponderResponseServiceFactory.Create(context)
                .Build(buildRequest);
        }

        private AutoresponderRequestModel CreateRequest(CreateResponseCommand request)
        {
            return new AutoresponderRequestModel
            {
                Article = request.Article,
                Rating = request.Rating,
                Text = request.Text
            };
        }
    }
}
