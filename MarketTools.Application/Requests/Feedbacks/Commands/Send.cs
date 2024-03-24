using MarketTools.Application.Interfaces.Feedbacks;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Feedbacks;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Feedbacks.Commands
{
    public class SendAnswerCommand() : IRequest<Unit>, IHttpConnectionContextCall
    {
        public EnumProjectServices Service { get; set; }
        public MarketplaceName MarketplaceName { get; set; }
        public required AnswerDto Data { get; set; }
        public int ConnectionId { get; set; }
    }

    public class CommandHandler(IConnectionServiceFactory<IFeedbacksService> _feedbacksServiceFactory,
        IConnectionDefinitionService _connectionDefinitionService)
        : IRequestHandler<SendAnswerCommand, Unit>
    {
        public async Task<Unit> Handle(SendAnswerCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionType connectionType = _connectionDefinitionService.Get(request.MarketplaceName, request.Service);
            await _feedbacksServiceFactory
                .Create(connectionType, request.MarketplaceName)
                .SendAnswerAsync(request.Data);

            return Unit.Value;
        }
    }
}
