using Domain;

namespace DataAccess.EFCore.Interfaces
{
    public interface ISttnRepository : IGenericRepository<Sttn>
    {
        Task<IEnumerable<Sttn>> GetBySysn(int sysn, bool includeDeleted);

        Task RemoveBySysn(int sysn);
    }
}