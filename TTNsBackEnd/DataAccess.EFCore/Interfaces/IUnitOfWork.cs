using Domain;

namespace DataAccess.EFCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISttnRepository STTNs { get; }

        IGenericRepository<Zttn> ZTTNs { get; }

        Task<bool> SaveAsync();
    }
}