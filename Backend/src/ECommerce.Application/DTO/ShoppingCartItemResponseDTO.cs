using System;

namespace ECommerce.Application.DTO
{
    public class ShoppingCartItemResponseDTO
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public ProductResponseDTO Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
