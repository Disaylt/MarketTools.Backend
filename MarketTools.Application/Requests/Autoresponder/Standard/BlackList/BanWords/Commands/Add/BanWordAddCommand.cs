using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.BanWords.Commands.Add
{
    public class BanWordAddCommand : IRequest<StandardAutoresponderBanWordEntity>
    {
        public required string Value { get; set; }
        public int BlackListId { get; set; }
    }
}
