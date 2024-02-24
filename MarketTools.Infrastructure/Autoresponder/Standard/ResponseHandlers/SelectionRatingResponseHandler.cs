﻿using DocumentFormat.OpenXml.InkML;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Autoresponder.Standard.ResponseHandlers
{
    internal class SelectionRatingResponseHandler : AutoresponderResponseHandler<AutoresponderRequestModel, StandardAutoresponderConnectionRatingEntity>
    {
        public override StandardAutoresponderConnectionRatingEntity Handle(AutoresponderRequestModel body)
        {
            StandardAutoresponderConnectionRatingEntity response = Find(body);
            ReportBuilder.AppendLine($"- Проверка на присутсвие списка шаблонов для оценки '{response.Rating}' успешно пройдена.");

            return response;
        }

        private StandardAutoresponderConnectionRatingEntity Find(AutoresponderRequestModel body)
        {
            return Context.Connection
                .Ratings
                .FirstOrDefault(x => x.Rating == body.Rating)
                ?? throw new Exception($"Не удалось найти список шаблонов для оценки '{body.Rating}'");
        }
    }
}