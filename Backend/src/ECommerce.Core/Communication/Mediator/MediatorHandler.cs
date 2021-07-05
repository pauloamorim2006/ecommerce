using ECommerce.Core.Messages.CommonMessages.DomainEvents;
using MediatR;
using System.Threading.Tasks;

namespace ECommerce.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish<T>(T notification) where T : DomainEvent
        {
            await _mediator.Publish(notification);
        }
    }
}