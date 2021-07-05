using ECommerce.Domain.Models;
using FluentValidation;

namespace ECommerce.Domain.Models.Validations
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("O campo Nome precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Nome precisa ter entre {MinLength} e {MaxLength} caracteres");            
        }
    }
}
