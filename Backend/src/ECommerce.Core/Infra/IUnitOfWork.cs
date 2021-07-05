using System.Threading.Tasks;

namespace ECommerce.Core.Infra
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
