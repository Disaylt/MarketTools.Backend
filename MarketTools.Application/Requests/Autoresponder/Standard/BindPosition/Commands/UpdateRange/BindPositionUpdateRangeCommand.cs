using MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Models;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ColumnBindPosition.Commands.UpdateRange
{
    public class BindPositionUpdateRangeCommand : IRequest<Unit>
    {
        public required AutoresponderColumnType ColumnType { get; set; }
        public int TemplateId { get; set; }
        public required IEnumerable<BindPositionDto> BindPositions { get; set; }
    }
}
