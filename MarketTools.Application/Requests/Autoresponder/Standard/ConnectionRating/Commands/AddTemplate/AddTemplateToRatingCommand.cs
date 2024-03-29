﻿using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Commands.AddTemplate
{
    public class AddTemplateToRatingCommand : IRequest<StandardAutoresponderTemplateEntity>
    {
        public int Rating { get; set; }
        public int TemplateId { get; set; }
        public int ConnectionId { get; set; }
    }
}
