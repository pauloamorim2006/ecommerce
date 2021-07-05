using ECommerce.Application.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTO
{
    public class ShoppingCartItemRequestDTO
    {
        [RequiredGuid]
        public Guid ProductId { get; set; }

        [Range(0.0000000000000001, Double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Quantity { get; set; }
    }
}
