using ECommerce.Core.Messages.CommonMessages.DomainEvents;
using System;

namespace ECommerce.Domain.Events
{
    public class ProductAddEvent : DomainEvent
    {
        public ProductAddEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
