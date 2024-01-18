using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.BlackList.Commands.Add
{
    public class BlackListAddCommand : IRequest<StandardAutoresponderBlackListEntity>
    {
        public required string Name {  get; set; }
    }
}
