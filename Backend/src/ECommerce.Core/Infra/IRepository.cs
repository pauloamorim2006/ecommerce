namespace ECommerce.Core.Infra
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
