using ECommerce.Core.DomainObjects;
using System;

namespace ECommerce.Domain.Models
{
    public class Image: Entity
    {
        protected Image()
        {
        }

        public Image(string name, Guid productId)
        {
            Name = name;
            ProductId = productId;
        }

        public string Name { get; private set; }

        public Guid ProductId { get; private set; }

        public Product Product { get; private set; }
    }
}
