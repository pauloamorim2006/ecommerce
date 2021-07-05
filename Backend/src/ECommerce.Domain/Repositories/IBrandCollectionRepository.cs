using ECommerce.Domain.Filter;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface IBrandCollectionRepository
    {
        Task<List<Brand>> Find(Guid subcategoryId);
    }
}
