using ECommerce.Domain.Models;
using ECommerce.Domain.Models.Validations;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Core.Notifications;
using ECommerce.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class SubcategoryService : BaseService, ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        public SubcategoryService(ISubcategoryRepository subcategoryRepository,
                                 INotifier notifier) : base(notifier)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<bool> Add(Subcategory register)
        {
            if (!ExecuteValidation(new SubcategoryValidation(), register)) return false;

            if (await _subcategoryRepository.Exists(register.Id, register.Name))
            {
                Notify("Já existe uma subcategoria com este nome.");
                return false;
            }

            _subcategoryRepository.Add(register);
            return await _subcategoryRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Update(Subcategory register)
        {
            if (!ExecuteValidation(new SubcategoryValidation(), register)) return false;

            if (await _subcategoryRepository.Exists(register.Id, register.Name))
            {
                Notify("Já existe uma subcategoria com este nome.");
                return false;
            }

            _subcategoryRepository.Update(register);
            return await _subcategoryRepository.UnitOfWork.Commit();
        }

        public async Task<List<Subcategory>> FindAll()
        {
            return await _subcategoryRepository.FindAll();
        }

        public async Task<Subcategory> FindById(Guid id)
        {
            return await _subcategoryRepository.FindById(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            if (_subcategoryRepository.FindById(id) == null)
            {
                Notify("Não existe nenhuma subcategoria com este Id.");
                return false;
            }

            await _subcategoryRepository.Remove(id);
            return await _subcategoryRepository.UnitOfWork.Commit();
        }
    }
}
