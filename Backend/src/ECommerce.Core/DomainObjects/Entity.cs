using FluentValidation.Results;
using System;

namespace ECommerce.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }

        public ValidationResult ValidationResult { get; set; }
    }
}