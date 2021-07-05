using ECommerce.Core.Messages.CommonMessages.DomainEvents;
using System;

namespace ECommerce.Domain.Events
{
    public class ProductUpdateEvent : DomainEvent
    {
        public ProductUpdateEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
