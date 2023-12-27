﻿using FluentValidation;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Validatiors;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Articles.Commands.Add
{
    public class CommandValidator : TemplateInteractValidator<AddCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, IUnitOfWork unitOfWork) : base(authUnitOfWork)
        {
            IRepository<StandardAutoresponderTemplateArticle> repository = unitOfWork.GetRepository<StandardAutoresponderTemplateArticle>();
            RuleFor(x => x)
                .MustAsync(async (value, ct) =>
                {
                    bool isExists = await repository.AnyAsync(entity =>
                        entity.Article == value.Article && entity.TemplateId == value.TemplateId);
                    return !isExists;
                })
                .WithMessage("Такой арткул уже добавлен.");
        }
    }
}