using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Commands.UpdateRange;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BindPosition.Commands.UpdateRange
{
    public class CommandHandler(IAuthUnitOfWork _authUnintOfWork)
        : IRequestHandler<BindPositionUpdateRangeCommand>
    {
        private readonly IRepository<StandardAutoresponderColumnBindPositionEntity> _bindPositionRepository = _authUnintOfWork.StandardAutoresponderColumnBindPositions;

        public Task Handle(BindPositionUpdateRangeCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
