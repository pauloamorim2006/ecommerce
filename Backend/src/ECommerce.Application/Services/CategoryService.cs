using ECommerce.Core.Notifications;
using ECommerce.Core.Services;
using ECommerce.Domain.Models;
using ECommerce.Domain.Models.Validations;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository,
                                 INotifier notifier) : base(notifier)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Add(Category register)
        {
            if (!ExecuteValidation(new CategoryValidation(), register)) return false;

            if (await _categoryRepository.Exists(register.Id, register.Name))
            {
                Notify("Já existe uma categoria com este nome.");
                return false;
            }

            _categoryRepository.Add(register);            
            return await _categoryRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Update(Category register)
        {
            if (!ExecuteValidation(new CategoryValidation(), register)) return false;

            if (await _categoryRepository.Exists(register.Id, register.Name))
            {
                Notify("Já existe uma categoria com este nome.");
                return false;
            }

            _categoryRepository.Update(register);
            return await _categoryRepository.UnitOfWork.Commit();
        }

        public async Task<List<Category>> FindAll()
        {
            return await _categoryRepository.FindAll();
        }

        public async Task<Category> FindById(Guid id)
        {
            return await _categoryRepository.FindById(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            if (_categoryRepository.FindById(id) == null)
            {
                Notify("Não existe nenhuma categoria com este Id.");
                return false;
            }

            await _categoryRepository.Remove(id);
            return await _categoryRepository.UnitOfWork.Commit();
        }
    }
}
