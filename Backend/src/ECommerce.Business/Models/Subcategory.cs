using ECommerce.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Models
{
    public class Subcategory : Entity
    {
        protected Subcategory()
        {
        }

        public Subcategory(Guid id, string name, Guid categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }

        public Subcategory(string name, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            CategoryId = categoryId;
        }

        public string Name { get; private set; }

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; }
    }
}
