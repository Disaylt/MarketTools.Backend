using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Cells.Queries
{
    public class CellGetRangeQuery : IRequest<IEnumerable<StandardAutoresponderCellEntity>>
    {
        public int CollumnId { get; set; }
    }

    public class GetRangeQueryValidator : AbstractValidator<CellGetRangeQuery>
    {
        public GetRangeQueryValidator(IAuthUnitOfWork authUnitOfWork)
        {
            RuleFor(x => x.CollumnId)
                .MustAsync(async (columnId, ct) =>
                {
                    return await authUnitOfWork.GetRepository<StandardAutoresponderColumnEntity>()
                        .AnyAsync(column => column.Id == columnId, ct);
                })
                .WithErrorCode("404")
                .WithMessage("Колонка не найдена.");
        }
    }

    public class GetRangeQueryHandler
        (IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<CellGetRangeQuery, IEnumerable<StandardAutoresponderCellEntity>>
    {
        private readonly IRepository<StandardAutoresponderCellEntity> _repository = _authUnitOfWork.GetRepository<StandardAutoresponderCellEntity>();
        public async Task<IEnumerable<StandardAutoresponderCellEntity>> Handle(CellGetRangeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x => x.ColumnId == request.CollumnId);
        }
    }
}
