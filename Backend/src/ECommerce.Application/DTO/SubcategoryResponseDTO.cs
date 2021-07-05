using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTO
{
    public class SubcategoryResponseDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
