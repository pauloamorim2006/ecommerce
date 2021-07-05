using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTO
{
    public class ProductUpdateRequestDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Marca")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Brand { get; set; }

        [Display(Name = "Cor")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Color { get; set; }

        [Display(Name = "Preço")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Fabricante")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Maker { get; set; }

        [Display(Name = "Número do Modelo")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Model { get; set; }

        [Display(Name = "Certificação do Modelo")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Certification { get; set; }

        [Display(Name = "Tipo de Material")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string TypeMaterial { get; set; }

        [Display(Name = "Quantidade")]
        [Required]
        public int Quantity { get; set; }

        [Display(Name = "Tamanho")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Size { get; set; }

        public string Details { get; set; }

        [Display(Name = "Avaliação")]
        [Required]
        public int Rating { get; set; }

        [Display(Name = "Frete Grátis")]
        [Required]
        public bool FreeShipping { get; set; }

        [Display(Name = "Marca")]
        [Required]
        public Guid BrandId { get; set; }

        [Display(Name = "Subcategoria")]
        [Required]
        public Guid SubcategoryId { get; set; }
    }
}
