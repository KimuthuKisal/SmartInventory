using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(validator => validator.Name)
                .NotEmpty().WithMessage("Enter the item name.")
                .MaximumLength(500).WithMessage("Name is too long. Please use description for more content.");

            RuleFor(validator => validator.Type)
                .NotEmpty().WithMessage("Enter the item name.");

            RuleFor(validator => validator.Count)
                .NotEmpty().WithMessage("Enter the item count.");

            RuleFor(validator => validator.UnitPriceSell)
                .NotEmpty().WithMessage("Enter the item sell price.");
        }
    }
}
