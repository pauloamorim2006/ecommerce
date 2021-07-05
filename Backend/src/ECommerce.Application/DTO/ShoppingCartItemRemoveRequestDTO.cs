using ECommerce.Application.Extensions;
using System;

namespace ECommerce.Application.DTO
{
    public class ShoppingCartItemRemoveRequestDTO
    {

        [RequiredGuid]
        public Guid ProductId { get; set; }
    }
}
