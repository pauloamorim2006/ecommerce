using ECommerce.Core.Messages.CommonMessages.DomainEvents;
using System;

namespace ECommerce.Domain.Events
{
    public class ProductRemoveEvent : DomainEvent
    {
        public ProductRemoveEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
