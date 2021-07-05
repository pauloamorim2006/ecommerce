using ECommerce.Core.Notifications;
using ECommerce.Core.Services;
using ECommerce.Domain.Filter;
using ECommerce.Domain.Models;
using ECommerce.Domain.Models.Validations;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class BrandService : BaseService, IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IBrandCollectionRepository _brandCollectionRepository;

        public BrandService(IBrandRepository brandRepository,
                            IBrandCollectionRepository brandCollectionRepository,
                            INotifier notifier) : base(notifier)
        {
            _brandRepository = brandRepository;
            _brandCollectionRepository = brandCollectionRepository;
        }

        public async Task<bool> Add(Brand register)
        {
            if (!ExecuteValidation(new BrandValidation(), register)) return false;

            if (await _brandRepository.Exists(register.Id, register.Name))
            {
                Notify("Já existe uma marca com este nome.");
                return false;
            }

            _brandRepository.Add(register);            
            return await _brandRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Update(Brand register)
        {
            if (!ExecuteValidation(new BrandValidation(), register)) return false;

            if (await _brandRepository.Exists(register.Id, register.Name))
            {
                Notify("Já existe uma marca com este nome.");
                return false;
            }

            _brandRepository.Update(register);
            return await _brandRepository.UnitOfWork.Commit();
        }

        public async Task<List<Brand>> Find(Guid subcategoryId)
        {
            return await _brandCollectionRepository.Find(subcategoryId);
        }

        public async Task<Brand> FindById(Guid id)
        {
            return await _brandRepository.FindById(id);
        }

        public async Task<List<Brand>> FindAll()
        {
            return await _brandRepository.FindAll();
        }

        public async Task<bool> Remove(Guid id)
        {
            if (_brandRepository.FindById(id) == null)
            {
                Notify("Não existe nenhuma marca com este Id.");
                return false;
            }

            await _brandRepository.Remove(id);
            return await _brandRepository.UnitOfWork.Commit();
        }
    }
}
