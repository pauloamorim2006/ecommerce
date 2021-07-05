using ECommerce.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> Find(Guid customerId);

        Task<bool> UpdateStatusInvoice(Guid customerId);

        Task<bool> UpdateStatusCanceled(Guid customerId);

        Task<ShoppingCart> AddShoppingCartItem(Guid customerId, ShoppingCartItem item);

        Task<ShoppingCart> UpdateShoppingCartItem(Guid customerId, ShoppingCartItem item);

        Task<ShoppingCart> RemoveShoppingCartItem(Guid customerId, ShoppingCartItem item);
    }
}
