using ECommerce.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Models
{
    public class Product : Entity, IAggregateRoot
    {
        protected Product()
        {
        }

        public Product(string name, string color, decimal price, string maker, string model, string certification, string typeMaterial, int quantity, string size, string details, int rating, bool freeShipping, Guid brandId, Guid subcategoryId)
        {
            Name = name;
            Color = color;
            Price = price;
            Maker = maker;
            Model = model;
            Certification = certification;
            TypeMaterial = typeMaterial;
            Quantity = quantity;
            Size = size;
            Details = details;
            Rating = rating;
            SubcategoryId = subcategoryId;
            BrandId = brandId;
            FreeShipping = freeShipping;

            _images = new List<Image>();
        }

        public Product(Guid id, string name, string color, decimal price, string maker, string model, string certification, string typeMaterial, int quantity, string size, string details, int rating, bool freeShipping, Guid brandId, Guid subcategoryId)
        {
            Id = id;
            Name = name;
            Color = color;
            Price = price;
            Maker = maker;
            Model = model;
            Certification = certification;
            TypeMaterial = typeMaterial;
            Quantity = quantity;
            Size = size;
            Details = details;
            Rating = rating;
            SubcategoryId = subcategoryId;
            BrandId = brandId;
            FreeShipping = freeShipping;

            _images = new List<Image>();
        }

        public string Name { get; private set; }        

        public string Color { get; private set; }

        public decimal Price { get; private set; }

        public string Maker { get; private set; }

        public string Model { get; private set; }

        public string Certification { get; private set; }

        public string TypeMaterial { get; private set; }

        public int Quantity { get; private set; }

        public string Size { get; private set; }

        public string Details { get; private set; }

        public int Rating { get; private set; }

        public bool FreeShipping { get; private set; }

        public Subcategory Subcategory { get; private set; }

        public Guid SubcategoryId { get; private set; }

        public Brand Brand { get; private set; }

        public Guid BrandId { get; private set; }

        private readonly List<Image> _images;

        public IReadOnlyCollection<Image> Images => _images;
    }
}
