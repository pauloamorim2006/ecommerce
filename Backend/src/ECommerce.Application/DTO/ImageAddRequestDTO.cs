using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTO
{
    public class ImageAddRequestDTO
    {
        [Required]
        public string Image { get; set; }

        public string ImageUpload { get; set; }
    }
}
