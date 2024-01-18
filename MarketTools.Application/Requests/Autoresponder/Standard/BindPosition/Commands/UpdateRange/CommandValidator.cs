using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Commands.UpdateRange;
using MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Models;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BindPosition.Commands.UpdateRange
{
    public class CommandValidator : CommonValidator<BindPositionUpdateRangeCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork) 
        {
            CanIntercatTemplate(RuleFor(x => x.TemplateId), authUnitOfWork);

            RuleFor(command => command)
                .MustAsync(async (command, ct) =>
                {
                    if (command.BindPositions.Count() == 0)
                    {
                        return true;
                    }

                    IEnumerable<StandardAutoresponderColumnEntity> entities = await authUnitOfWork.StandardAutoresponderColumns
                        .GetRangeAsync(x => x.Type == command.ColumnType, ct);
                    IEnumerable<int> columnsIds = entities.Select(x => x.Id);

                    return command.BindPositions
                        .All(bind => columnsIds.Contains(bind.ColumnId));
                });
        }
    }
}
