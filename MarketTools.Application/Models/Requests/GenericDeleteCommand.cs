using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Requests
{
    public class GenericDeleteCommand<TEntity> : IRequest
    {
        public int Id { get; set; }
    }
}
