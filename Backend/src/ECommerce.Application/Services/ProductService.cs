using ECommerce.Domain.Models;
using ECommerce.Domain.Models.Validations;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Core.Notifications;
using ECommerce.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Communication.Mediator;
using ECommerce.Domain.Events;
using ECommerce.Domain.Filter;

namespace ECommerce.Application.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCollectionRepository _productCollectionRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public ProductService(IProductRepository productRepository,
                              IProductCollectionRepository productCollectionRepository,
                              IMediatorHandler mediatorHandler,
                              INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
            _mediatorHandler = mediatorHandler;
            _productCollectionRepository = productCollectionRepository;
        }

        public async Task<bool> Add(Product register)
        {
            if (!ExecuteValidation(new ProductValidation(), register)) return false;

            if (await _productRepository.Exists(register.Id, register.Name))
            {
                Notify("Já existe um produto com este nome.");
                return false;
            }

            _productRepository.Add(register);
            var result = await _productRepository.UnitOfWork.Commit();
            
            if (result) await _mediatorHandler.Publish(new ProductAddEvent(register.Id));

            return result;
        }

        public async Task<bool> Update(Product register)
        {
            if (!ExecuteValidation(new ProductValidation(), register)) return false;

            if (await _productRepository.Exists(register.Id, register.Name))
            {
                Notify("Já existe um produto com este nome.");
                return false;
            }

            _productRepository.Update(register);
            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<List<Product>> FindAll()
        {
            return await _productRepository.FindAll();
        }

        public async Task<Product> FindById(Guid id)
        {
            return await _productRepository.FindById(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            if (_productRepository.FindById(id) == null)
            {
                Notify("Não existe nenhum Produto com este Id.");
                return false;
            }

            await _productRepository.Remove(id);
            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> AddImage(Image entity)
        {
            if (!ExecuteValidation(new ImageValidation(), entity)) return false;

            _productRepository.AddImage(entity);
            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<(List<Product>, int)> Find(Guid subcategoryId, ProductFilter filter)
        {
            return await _productCollectionRepository.Find(subcategoryId, filter);
        }
    }
}
