using ECommerce.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Models
{
    public class Category : Entity
    {
        protected Category()
        {
        }

        public Category(Guid id, string name, string image)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            Image = image;
            _subcategories = new List<Subcategory>();
        }

        public Category(string name, string image)
        {
            Id = Guid.NewGuid();
            Name = name;
            Image = image;            
            _subcategories = new List<Subcategory>();
        }

        public string Name { get; private set; }

        public string Image { get; private set; }

        private readonly List<Subcategory> _subcategories;

        public IReadOnlyCollection<Subcategory> Subcategories => _subcategories;


    }
}
