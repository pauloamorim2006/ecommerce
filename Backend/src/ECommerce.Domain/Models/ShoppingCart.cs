using ECommerce.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Domain.Models
{
    public class ShoppingCart : Entity, IAggregateRoot
    {
        protected ShoppingCart()
        {
        }

        public ShoppingCart(Guid customerId, decimal discount, decimal total)
        {           
            CustomerId = customerId;
            IssueDate = DateTime.Now;
            Discount = discount;
            Total = total;
            ShoppingCartStatus = ShoppingCartStatus.Open;
            _items = new List<ShoppingCartItem>();
        }

        public ShoppingCartStatus ShoppingCartStatus { get; private set; }

        public DateTime IssueDate { get; private set; }

        public Guid CustomerId { get; private set; }

        public decimal Discount { get; private set; }

        public decimal Total { get; private set; }

        private readonly List<ShoppingCartItem> _items;

        public IReadOnlyCollection<ShoppingCartItem> Items => _items;

        public void SetStatus(ShoppingCartStatus status)
        {
            ShoppingCartStatus = status;
        }

        public void CalculateTotal()
        {
            Total = Items.Sum(p => p.CalculateTotal());
            CalculateTotalDiscount();
        }

        public void CalculateTotalDiscount()
        {
            Total = Total - Discount;
        }

        public bool ExistisItem(ShoppingCartItem item)
        {
            return _items.Any(p => p.ProductId == item.ProductId);
        }

        public void AddItem(ShoppingCartItem item)
        {
            if (!item.IsValidate()) return;

            item.AssociateShoppingCart(Id);

            if (ExistisItem(item))
            {
                var itemExistente = _items.FirstOrDefault(p => p.ProductId == item.ProductId);
                itemExistente.AddQuantity(item.Quantity);
                item = itemExistente;

                _items.Remove(itemExistente);
            }

            item.CalculateTotal();
            _items.Add(item);

            CalculateTotal();
        }

        public void RemoveItem(ShoppingCartItem item)
        {
            if (!item.IsValidate()) return;

            var itemExistente = Items.FirstOrDefault(p => p.ProductId == item.ProductId);

            if (itemExistente == null) throw new DomainException("O item não pertence ao pedido");
            _items.Remove(itemExistente);

            CalculateTotal();
        }

        public void UpdateItem(ShoppingCartItem item)
        {
            if (!item.IsValidate()) return;
            item.AssociateShoppingCart(Id);

            var existsItem = Items.FirstOrDefault(p => p.ProductId == item.ProductId);

            if (existsItem == null) throw new DomainException("O item não pertence ao pedido");

            _items.Remove(existsItem);
            _items.Add(item);

            CalculateTotal();
        }

        public void UpdateQuantity(ShoppingCartItem item, int quantity)
        {
            item.UpdateQuantity(quantity);
            UpdateItem(item);
        }

        public static class ShoppingCartFactory
        {
            public static ShoppingCart NewShoppingCart(Guid customerId)
            {
                var shoppingCart = new ShoppingCart(customerId, 0, 0);

                return shoppingCart;
            }
        }
    }
}
