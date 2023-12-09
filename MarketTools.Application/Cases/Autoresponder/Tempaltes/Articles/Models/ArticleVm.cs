﻿using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models
{
    public class ArticleVm : IHasMap
    {
        public required string Article { get; set; }
        public int TemplateId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AutoresponderTemplateArticle, ArticleVm>();
        }
    }
}