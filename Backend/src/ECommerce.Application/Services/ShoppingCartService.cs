using ECommerce.Core.Notifications;
using ECommerce.Core.Services;
using ECommerce.Domain.Models;
using ECommerce.Domain.Models.Validations;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository,
                                 IProductRepository productRepository,
                                 INotifier notifier) : base(notifier)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public async Task<bool> UpdateStatusInvoice(Guid customerId)
        {
            var cart = await _shoppingCartRepository.FindByCustomer(customerId);

            if (cart == null)
            {
                Notify("O Carrinho de Compra não foi encontrado!");
                return false;
            }

            if(cart.ShoppingCartStatus == ShoppingCartStatus.Canceled || cart.ShoppingCartStatus == ShoppingCartStatus.Invoice)
            {
                Notify("O Carrinho de Compra deve estar com status 'Aberto' para ser faturado!");
                return false;
            }

            cart.SetStatus(ShoppingCartStatus.Invoice);
            _shoppingCartRepository.Update(cart);
            return await _shoppingCartRepository.UnitOfWork.Commit();

        }

        public async Task<bool> UpdateStatusCanceled(Guid customerId)
        {
            var cart = await _shoppingCartRepository.FindByCustomer(customerId);

            if (cart == null)
            {
                Notify("O Carrinho de Compra não foi encontrado!");
                return false;
            }

            if (cart.ShoppingCartStatus == ShoppingCartStatus.Canceled || cart.ShoppingCartStatus == ShoppingCartStatus.Invoice)
            {
                Notify("O Carrinho de Compra deve estar com status 'Aberto' para ser faturado!");
                return false;
            }

            cart.SetStatus(ShoppingCartStatus.Canceled);
            _shoppingCartRepository.Update(cart);
            return await _shoppingCartRepository.UnitOfWork.Commit();
        }

        public async Task<ShoppingCart> AddShoppingCartItem(Guid customerId, ShoppingCartItem item)
        {
            if (!ExecuteValidation(new ShoppingCartItemValidation(), item)) return null;

            var cart = await _shoppingCartRepository.FindByCustomer(customerId);
            var product = await _productRepository.FindById(item.ProductId);

            if (product == null)
            {
                Notify("O Produto informado não existe!");
                return null;
            }

            var cartItem = new ShoppingCartItem(item.ProductId, item.Quantity, product.Price);

            if (cart == null)
            {
                cart = ShoppingCart.ShoppingCartFactory.NewShoppingCart(customerId);
                cart.AddItem(cartItem);

                _shoppingCartRepository.Add(cart);                
            }
            else
            {
                var existsCart = cart.ExistisItem(cartItem);
                cart.AddItem(cartItem);

                if (existsCart)
                {
                    _shoppingCartRepository.UpdateCartItem(cart.Items.FirstOrDefault(p => p.ProductId == cartItem.ProductId));
                }
                else
                {
                    _shoppingCartRepository.AddCartItem(cartItem);
                }
            }

            await _shoppingCartRepository.UnitOfWork.Commit();

            var shoppingCart = await _shoppingCartRepository.FindByCustomer(customerId);

            return shoppingCart;
        }

        public async Task<ShoppingCart> UpdateShoppingCartItem(Guid customerId, ShoppingCartItem item)
        {
            if (!ExecuteValidation(new ShoppingCartItemValidation(), item)) return null;

            var cart = await _shoppingCartRepository.FindByCustomer(customerId);

            if (cart == null)
            {
                Notify("O Carrinho de Compra não foi encontrado!");
                return null;
            }

            var cartItem = await _shoppingCartRepository.FindItemByCart(cart.Id, item.ProductId);

            if (cartItem == null)
            {
                Notify("O item não foi encontrado!");
                return null;
            }

            if (!cart.ExistisItem(cartItem))
            {
                Notify("O item não foi encontrado!");
                return null;
            }

            cart.UpdateQuantity(cartItem, item.Quantity);

            _shoppingCartRepository.UpdateCartItem(cartItem);
            _shoppingCartRepository.Update(cart);

            await _shoppingCartRepository.UnitOfWork.Commit();

            return await _shoppingCartRepository.FindByCustomer(customerId);
        }

        public async Task<ShoppingCart> RemoveShoppingCartItem(Guid customerId, ShoppingCartItem item)
        {
            var cart = await _shoppingCartRepository.FindByCustomer(customerId);

            if (cart == null)
            {
                Notify("O Carrinho de Compra não foi encontrado!");
                return null;
            }

            var product = await _productRepository.FindById(item.ProductId);

            if (product == null)
            {
                Notify("O Produto informado não existe!");
                return null;
            }

            var cartItem = await _shoppingCartRepository.FindItemByCart(cart.Id, item.ProductId);

            if (cartItem == null)
            {
                Notify("O item não foi encontrado!");
                return null;
            }

            if (!cart.ExistisItem(cartItem))
            {
                Notify("O item não foi encontrado!");
                return null;
            }

            cart.RemoveItem(cartItem);

            _shoppingCartRepository.RemoveCartItem(cartItem);
            _shoppingCartRepository.Update(cart);

            await _shoppingCartRepository.UnitOfWork.Commit();

            return await _shoppingCartRepository.FindByCustomer(customerId);
        }

        public async Task<ShoppingCart> Find(Guid customerId)
        {
            return await _shoppingCartRepository.FindByCustomer(customerId);
        }
    }
}
