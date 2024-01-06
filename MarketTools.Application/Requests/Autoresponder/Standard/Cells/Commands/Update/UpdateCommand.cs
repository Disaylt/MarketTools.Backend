using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Update
{
    public class UpdateCommand : IRequest<StandardAutoresponderCell>
    {
        public int Id { get; set; }
        public required string Value { get; set; }
    }
}
