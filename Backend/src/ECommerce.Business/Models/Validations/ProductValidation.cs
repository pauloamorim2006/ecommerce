using FluentValidation;
using System;

namespace ECommerce.Domain.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("O campo Descrição precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Descrição precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.BrandId)
                .NotEqual(Guid.Empty).WithMessage("O campo Marca precisa ser fornecido");

            RuleFor(f => f.SubcategoryId)
                .NotEqual(Guid.Empty).WithMessage("O campo Subcategoria precisa ser fornecido");

            RuleFor(f => f.Color)
                .NotEmpty().WithMessage("O campo Descrição precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Descrição precisa ter entre {MinLength} e {MaxLength} caracteres");            

            RuleFor(f => f.Price)
                .GreaterThanOrEqualTo(0).WithMessage("O campo Preço precisa ser maior que zezo");

            RuleFor(f => f.Maker)
                .NotEmpty().WithMessage("O campo Fabricante precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Descrição precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Model)
                .NotEmpty().WithMessage("O campo Número do Modelo precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Número precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Certification)
                .NotEmpty().WithMessage("O campo Certificação do Modelo precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Certificação precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.TypeMaterial)
                .NotEmpty().WithMessage("O campo Tipo de Material precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Tipo de Material precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Size)
                .NotEmpty().WithMessage("O campo Tamanho precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo Tamanho precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
