using FluentValidation;
using System;

namespace ECommerce.Domain.Models.Validations
{
    public class ImageValidation : AbstractValidator<Image>
    {
        public ImageValidation()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("O campo Imagem precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Nome precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.ProductId)
                .NotEqual(Guid.Empty).WithMessage("O campo Produto precisa ser fornecido");
        }
    }
}
