using ECommerce.Core.DomainObjects;
using System;

namespace ECommerce.Domain.Models
{
    public class Brand : Entity
    {
        public string Name { get; private set; }

        public Brand(string name)
        {
            Name = name;
        }

        public Brand(Guid id, string name)
        {
            Name = name;
        }
    }
}
