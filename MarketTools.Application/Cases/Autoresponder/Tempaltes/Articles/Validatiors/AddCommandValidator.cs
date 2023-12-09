﻿using FluentValidation;
using MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Models;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Articles.Validations
{
    public class AddCommandValidator<T> : AbstractValidator<T> where T : AddCommand
    {
        public AddCommandValidator(IAuthUnitOfWork authUnitOfWork)
        {
            RuleFor(x => x.TemplateId)
                .MustAsync(async (v, ct) =>
                {
                    return await authUnitOfWork.AutoresponderTemplates.AnyAsync(x => x.Id == v);
                })
                .WithErrorCode("404")
                .WithMessage("Шаблон не найден.");
        }
    }
}