using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface IShoppingCartRepository : IRepository
    {
        Task<ShoppingCart> FindByCustomer(Guid customerId);

        Task<ShoppingCartItem> FindItemByCart(Guid shoppingCartId, Guid productId);

        void Add(ShoppingCart cart);

        void Update(ShoppingCart cart);

        void UpdateCartItem(ShoppingCartItem cartItem);

        void AddCartItem(ShoppingCartItem cartItem);

        void RemoveCartItem(ShoppingCartItem cartItem);
    }
}
