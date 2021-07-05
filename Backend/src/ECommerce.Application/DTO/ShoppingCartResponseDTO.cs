using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;

namespace ECommerce.Application.DTO
{
    public class ShoppingCartResponseDTO
    {
        public Guid Id { get; set; }

        public ShoppingCartStatus ShoppingCartStatus { get; set; }

        public DateTime IssueDate { get; set; }

        public Guid CustomerId { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }

        public List<ShoppingCartItemResponseDTO> Items { get; set; }
    }
}
