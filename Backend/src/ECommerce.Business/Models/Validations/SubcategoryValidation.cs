using FluentValidation;
using System;

namespace ECommerce.Domain.Models.Validations
{
    public class SubcategoryValidation : AbstractValidator<Subcategory>
    {
        public SubcategoryValidation()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("O campo Nome precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Nome precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.CategoryId)
                .NotEqual(Guid.Empty).WithMessage("O campo Categoria precisa ser fornecido");
        }
    }
}
