using FluentValidation;
using System;

namespace ECommerce.Domain.Models.Validations
{
    public class ShoppingCartValidation : AbstractValidator<ShoppingCart>
    {
        public ShoppingCartValidation()
        {
            RuleFor(f => f.CustomerId)
                .NotEqual(Guid.Empty).WithMessage("O campo Cliente precisa ser fornecido");
        }
    }
}
