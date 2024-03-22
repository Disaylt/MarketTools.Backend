using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Feedbacks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Reports.Commands
{
    public class CreateReportCommand() : IRequest<Unit>
    {
        public required FeedbackDto Feedback { get; set; }
        public required AutoresponderResultModel Result { get; set; }
        public int ConnectionId { get; set; }
    }

    public class CommandHandler(IAutoresponderReportsService _autoresponderReportsService, IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateReportCommand, Unit>
    {
        public async Task<Unit> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            await _autoresponderReportsService.AddAsync(request.Feedback, request.Result, request.ConnectionId);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
