using FluentValidation;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Cells.Commands
{
    public class CellCreateCommand : IRequest<StandardAutoresponderCellEntity>
    {
        public int ColumnId { get; set; }
        public required string Value { get; set; }
    }

    public class CreateCommandValidator : AbstractValidator<CellCreateCommand>
    {
        public CreateCommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            IRepository<StandardAutoresponderCellEntity> cellsRepository = authUnitOfWork.GetRepository<StandardAutoresponderCellEntity>();
            IRepository<StandardAutoresponderColumnEntity> columnRepository = authUnitOfWork.GetRepository<StandardAutoresponderColumnEntity>();
            RuleFor(x => x.ColumnId)
                .MustAsync(async (columnId, ct) =>
                {
                    return await columnRepository.AnyAsync(x => x.Id == columnId);
                })
                .WithErrorCode("404")
                .WithMessage("Колонка не найдена.");

            RuleFor(x => x.ColumnId)
                .MustAsync(async (columnId, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalCells = await cellsRepository.CountAsync(x => x.ColumnId == columnId);

                    return totalCells < limits.MaxCells;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит ячеек.");
        }
    }

    public class CreateCommandHandler(IUnitOfWork _unitOfWork)
        : IRequestHandler<CellCreateCommand, StandardAutoresponderCellEntity>
    {
        private readonly IRepository<StandardAutoresponderCellEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderCellEntity>();

        public async Task<StandardAutoresponderCellEntity> Handle(CellCreateCommand request, CancellationToken cancellationToken)
        {
            StandardAutoresponderCellEntity entity = Create(request);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        private StandardAutoresponderCellEntity Create(CellCreateCommand request)
        {
            return new StandardAutoresponderCellEntity
            {
                ColumnId = request.ColumnId,
                Value = request.Value
            };
        }
    }
}
