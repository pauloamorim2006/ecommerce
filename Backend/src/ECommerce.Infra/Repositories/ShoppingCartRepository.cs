using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Infra.Context.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infra.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ECommerceDbContext _context;

        public ShoppingCartRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(ShoppingCart cart)
        {
            _context.Add(cart);
        }

        public void AddCartItem(ShoppingCartItem cartItem)
        {
            _context.ShoppingCartItems.Add(cartItem);
        }

        public async Task<ShoppingCart> FindByCustomer(Guid customerId)
        {
            return await _context.ShoppingCarts
                .Include(x => x.Items)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(j => j.Images)
                .Include(x => x.Items)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(j => j.Brand)
                .Include(x => x.Items)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(j => j.Subcategory)
                .Where(x => x.ShoppingCartStatus == ShoppingCartStatus.Open && x.CustomerId == customerId)
                .AsTracking()
                .FirstOrDefaultAsync();
        }

        public void UpdateCartItem(ShoppingCartItem cartItem)
        {
            _context.ShoppingCartItems.Update(cartItem);
        }

        public async Task<ShoppingCartItem> FindItemByCart(Guid shoppingCartId, Guid productId)
        {
            return await _context.ShoppingCartItems
                .Where(x => x.ShoppingCartId == shoppingCartId && x.ProductId == productId)
                .AsTracking()
                .FirstOrDefaultAsync();
        }

        public void Update(ShoppingCart cart)
        {
            _context.ShoppingCarts.Update(cart);
        }

        public void RemoveCartItem(ShoppingCartItem cartItem)
        {
            _context.ShoppingCartItems.Remove(cartItem);
        }
    }
}
