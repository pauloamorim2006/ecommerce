using FluentValidation;
using System;

namespace ECommerce.Domain.Models.Validations
{
    public class ShoppingCartItemValidation : AbstractValidator<ShoppingCartItem>
    {
        public ShoppingCartItemValidation()
        {
            RuleFor(f => f.ProductId)
                .NotEqual(Guid.Empty).WithMessage("O campo Produto precisa ser fornecido");

            RuleFor(f => f.Price)
                .GreaterThanOrEqualTo(0).WithMessage("O campo Valor Unitário precisa ser maior do que zero");

            RuleFor(f => f.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("O campo Quantidade precisa ser maior do que zero");

        }
    }
}
