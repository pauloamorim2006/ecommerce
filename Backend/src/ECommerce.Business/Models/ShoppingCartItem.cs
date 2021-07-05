using ECommerce.Core.DomainObjects;
using ECommerce.Domain.Models.Validations;
using System;

namespace ECommerce.Domain.Models
{
    public class ShoppingCartItem : Entity
    {
        protected ShoppingCartItem()
        {
        }

        public ShoppingCartItem(Guid productId, int quantity, decimal price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Guid ShoppingCartId { get; private set; }

        public ShoppingCart ShoppingCartMyProperty { get; private set; }

        public Guid ProductId { get; private set; }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public decimal CalculateTotal()
        {
            return Quantity * Price;
        }

        internal void AssociateShoppingCart(Guid shoppingCartId)
        {
            ShoppingCartId = shoppingCartId;
        }

        internal void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        internal void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public bool IsValidate()
        {
            var validate = new ShoppingCartItemValidation().Validate(this);
            return validate.IsValid;
        }
    }
}
