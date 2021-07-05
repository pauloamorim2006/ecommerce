using ECommerce.Core.Messages.CommonMessages.DomainEvents;
using System.Threading.Tasks;

namespace ECommerce.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task Publish<T>(T notification) where T : DomainEvent;
    }
}