using ECommerce.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Domain.Events
{
    public class ProductEventHandler : 
        INotificationHandler<ProductAddEvent>,
        INotificationHandler<ProductUpdateEvent>,
        INotificationHandler<ProductRemoveEvent>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCollectionRepository _productCollectionRepository;

        public ProductEventHandler(IProductRepository productRepository,
            IProductCollectionRepository productCollectionRepository)
        {
            _productRepository = productRepository;
            _productCollectionRepository = productCollectionRepository;
        }

        public async Task Handle(ProductAddEvent notification, CancellationToken cancellationToken)
        {
            var register = await _productRepository.FindById(notification.AggregateId);
            await _productCollectionRepository.Add(register);
        }

        public async Task Handle(ProductUpdateEvent notification, CancellationToken cancellationToken)
        {
            var register = await _productRepository.FindById(notification.AggregateId);
            await _productCollectionRepository.Update(register);
        }

        public async Task Handle(ProductRemoveEvent notification, CancellationToken cancellationToken)
        {
            await _productCollectionRepository.Remove(notification.AggregateId);
        }
    }
}
