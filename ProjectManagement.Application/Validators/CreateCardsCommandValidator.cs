using FluentValidation;
using ProjectManagement.Application.Cards.Commands.CreateCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Validators
{
    public class CreateCardsCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardsCommandValidator()
        {
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.NotificationEmail).NotEmpty();
        }
    }
}
